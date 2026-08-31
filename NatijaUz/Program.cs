using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.Services.Auth;
using NatijaUz.Application.Auth.Services.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using NatijaUz.Application.Services.UserService.Commands.Create;
using NatijaUz.Application.Auth.Services.RegisterService.Services;
using NatijaUz.Application.Auth.Services.RegisterService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

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
    options.ExpireTimeSpan = TimeSpan.FromHours(7);
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

//Mediatr
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
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