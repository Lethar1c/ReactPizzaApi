using ReactPizza.DataAccess.Models;

namespace ReactPizza.DataAccess.Repositories
{
    public interface IPizzaRepository
    {
        public Task<Pizza> AddPizza(Pizza pizza);
        public Task<Pizza?> GetPizza(int id);
        public Task<List<Pizza>> GetAllPizzas();
        public Task<Pizza?> UpdatePizza(int id, Pizza newPizza);
        public Task DeletePizza(int id);
    }
}
