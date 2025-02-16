using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactPizza.WebApi.Pizzas.Dtos;
using ReactPizza.WebApi.Pizzas.Services;

namespace ReactPizza.WebApi.Pizzas.Controllers
{
    [ApiController]
    [Route("/api/pizza")]
    public class PizzaController
    {
        private readonly IPizzaService _pizzaService = null!;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<List<PizzaDto?>> GetAllPizzas()
        {
            return await _pizzaService.GetAllPizzas();
        }
        [HttpGet("{id}")]
        public async Task<PizzaDto?> GetPizza(int id)
        {
            return await _pizzaService.GetPizza(id);
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPost]
        public async Task<PizzaDto?> AddPizza(PizzaDto pizza)
        {
            return await _pizzaService.AddPizza(pizza);
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpPut("{id}")]
        public async Task<PizzaDto?> UpdatePizza(int id, PizzaDto newPizza)
        {
            return await _pizzaService.UpdatePizza(id, newPizza);
        }

        [Authorize(Roles = "admin, superadmin")]
        [HttpDelete("{id}")]
        public async Task DeletePizza(int id)
        {
            await _pizzaService.DeletePizza(id);
        }

    }
}
