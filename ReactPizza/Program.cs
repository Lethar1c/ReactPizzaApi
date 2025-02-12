using ReactPizza.DataAccess;
using ReactPizza.DataAccess.Repositories;
using ReactPizza.WebApi.Pizzas.Services;

var builder = WebApplication.CreateBuilder(args);

ApplicationContext context = new();

builder.Services.AddControllers();
builder.Services.AddSingleton<ApplicationContext, ApplicationContext>();
builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddTransient<IPizzaService, PizzaService>();

var app = builder.Build();

app.MapControllers();

app.Run();
