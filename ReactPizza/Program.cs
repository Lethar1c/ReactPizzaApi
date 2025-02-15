using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ReactPizza;
using ReactPizza.DataAccess;
using ReactPizza.DataAccess.Repositories;
using ReactPizza.WebApi.Pizzas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = "",
        ValidateAudience = true,
        ValidAudience = "",
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true,
    };
});

ApplicationContext context = new();

builder.Services.AddControllers();
builder.Services.AddSingleton<ApplicationContext, ApplicationContext>();
builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddTransient<IPizzaService, PizzaService>();

var app = builder.Build();

app.MapControllers();

app.Run();
