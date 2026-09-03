using RabbitMQ.Client;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Common;
using Microsoft.AspNetCore.Authentication;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.AuthService;
using NatijaUz.Application.Auth.AccountService;
using Microsoft.AspNetCore.Authentication.Cookies;
using NatijaUz.Application.Auth.Services.VerifyEmail.Services;
using NatijaUz.Application.Auth.Services.VerifyEmail.Interfaces;
using NatijaUz.Application.Services.UserService.Commands.Create;
using NatijaUz.Application.Services.UserService.Queries.GetList;

var builder = WebApplication.CreateBuilder(args);

//Docker - RabbitMQ ulanish
builder.Services.AddSingleton<IConnection>(sp =>
{
    var factory = new ConnectionFactory
    {
        HostName = "localhost",
        UserName = "admin",
        Password = "admin123"
    };
    return factory.CreateConnectionAsync().GetAwaiter().GetResult();
});

builder.Services.AddSingleton<IChannel>(sp =>
{
    var connection = sp.GetRequiredService<IConnection>();
    return connection.CreateChannelAsync().GetAwaiter().GetResult();
});

builder.Services.AddSingleton<IMessagePublisher, RabbitMqPublisher>();

// PostgreSQL ulanish
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// COOKIE AUTHENTICATION
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/api/Auth/Login";
    options.LogoutPath = "/api/Auth/Logout";
    options.ExpireTimeSpan = TimeSpan.FromHours(3);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

    options.Events = new CookieAuthenticationEvents
    {
        OnValidatePrincipal = async ctx =>
        {
            var userIdClaim = ctx.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !long.TryParse(userIdClaim, out var userId))
            {
                ctx.RejectPrincipal();
                return;
            }

            var dbContext = ctx.HttpContext.RequestServices.GetRequiredService<AppDbContext>();
            var exists = await dbContext.Users.AnyAsync(u => u.Id == userId);

            if (!exists)
            {
                ctx.RejectPrincipal();
                await ctx.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        },
        OnRedirectToLogin = ctx =>
        {
            ctx.Response.StatusCode = 401;
            return Task.CompletedTask;
        },
        OnRedirectToAccessDenied = ctx =>
        {
            ctx.Response.StatusCode = 403;
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();

// DATA PROTECTION
/*builder.Services.AddDataProtection()
.SetApplicationName("UzMarketWebApi")
.PersistKeysToDbContext<AppDbContext>();*/
builder.Services.AddHttpContextAccessor();

// Swagger ishlash
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailSender, MailKitEmailSender>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICacheService, MemoryCacheService>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

//Email ishlashi uchun
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

//Mediatr
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetListCommand).Assembly);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// MIDDLEWARE 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();