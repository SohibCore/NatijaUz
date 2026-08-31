using Microsoft.EntityFrameworkCore;
using NatijaUz.Application.Auth.Services.Account;
using NatijaUz.Application.Services.UserService.Commands.Create;
using NatijaUz.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL ulanish
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// DATA PROTECTION
/*builder.Services.AddDataProtection()
.SetApplicationName("UzMarketWebApi")
.PersistKeysToDbContext<AppDbContext>();
builder.Services.AddHttpContextAccessor();*/

// Swagger ishlash
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<IAccountService, AccountService>();

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