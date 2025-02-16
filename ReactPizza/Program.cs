using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ReactPizza;
using ReactPizza.DataAccess;
using ReactPizza.DataAccess.Repositories;
using ReactPizza.WebApi.Authentication.Services;
using ReactPizza.WebApi.Pizzas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true,
    };
});

ApplicationContext context = new();


builder.Services.AddControllers();
builder.Services.AddSingleton<ApplicationContext, ApplicationContext>();
builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddSingleton<IPizzaService, PizzaService>();
builder.Services.AddSingleton<IPasswordService, PasswordService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.MapControllers();

app.Run();
