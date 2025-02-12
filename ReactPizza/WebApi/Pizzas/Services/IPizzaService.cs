using ReactPizza.WebApi.Pizzas.Dtos;

namespace ReactPizza.WebApi.Pizzas.Services
{
    public interface IPizzaService
    {
        public Task<PizzaDto?> AddPizza(PizzaDto pizza);
        public Task<PizzaDto?> GetPizza(int id);
        public Task<List<PizzaDto?>> GetAllPizzas();
        public Task<PizzaDto?> UpdatePizza(int id, PizzaDto newPizza);
        public Task DeletePizza(int id);
    }
}
