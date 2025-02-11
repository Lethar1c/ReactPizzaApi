using ReactPizza.DataAccess.Models;
using ReactPizza.DataAccess.Repositories;
using ReactPizza.WebApi.Pizzas.Dtos;
using Type = ReactPizza.DataAccess.Models.Type;

namespace ReactPizza.WebApi.Pizzas.Services
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _repository;
        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }

        private PizzaDto? PizzaToDto(Pizza? pizza)
        {
            if (pizza == null) return null;
            List<Tuple<int, decimal>> sizes = [];
            List<Tuple<int, string>> types = [];

            foreach (Size size in pizza.Sizes)
            {
                sizes.Add(new Tuple<int, decimal>(size.Cantimeters, size.Price));
            }

            foreach (Type type in pizza.Types)
            {
                types.Add(new Tuple<int, string>(type.Id, type.Name));
            }

            return new PizzaDto
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Rating = pizza.Rating,
                Sizes = sizes,
                Types = types
            };
        }

        public async Task<PizzaDto> AddPizza(Pizza pizza)
        {
            Pizza addedPizza = await _repository.AddPizza(pizza);
            return PizzaToDto(addedPizza);
        }

        public async Task DeletePizza(int id)
        {
            await _repository.DeletePizza(id);
        }

        public async Task<List<PizzaDto>> GetAllPizzas()
        {
            List<PizzaDto> pizzas = (await _repository.GetAllPizzas()).Select(p => PizzaToDto(p)).ToList();
            return pizzas;
        }

        public async Task<PizzaDto?> GetPizza(int id)
        {
            PizzaDto? pizza = PizzaToDto(await _repository.GetPizza(id));
            return pizza;
        }

        public async Task<PizzaDto?> UpdatePizza(int id, Pizza newPizza)
        {
            PizzaDto? pizza = PizzaToDto(await _repository.UpdatePizza(id, newPizza));
            return pizza;
        }
    }
}
