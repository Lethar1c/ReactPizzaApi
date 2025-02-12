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

        private static PizzaDto? PizzaToDto(Pizza? pizza)
        {
            if (pizza == null) return null;
            List<SizeDto> sizes = [];
            List<TypeDto> types = [];

            foreach (Size size in pizza.Sizes)
            {
                sizes.Add(new SizeDto(size.Cantimeters, size.Price));
            }

            foreach (Type type in pizza.Types)
            {
                types.Add(new TypeDto(type.Id, type.Name));
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
        private static Pizza? DtoToPizza(PizzaDto? pizzaDto)
        {
            if (pizzaDto == null) return null;
            List<Size> sizes = [];
            List<Type> types = [];
            foreach (var type in pizzaDto.Types)
            {
                types.Add(new Type(type.Id, type.Name));
            }
            foreach (var size in pizzaDto.Sizes)
            {
                sizes.Add(new Size(size.Diameter, size.Price));
            }
            Pizza newPizza = new()
            {
                Name = pizzaDto.Name,
                Description = pizzaDto.Description,
                Rating = pizzaDto.Rating,
                Sizes = sizes,
                Types = types
            };
            return newPizza;
        }

        public async Task<PizzaDto?> AddPizza(PizzaDto pizzaDto)
        {
            Pizza? newPizza = DtoToPizza(pizzaDto);
            if (newPizza == null) return null;
            return PizzaToDto(await _repository.AddPizza(newPizza));
        }

        public async Task DeletePizza(int id)
        {
            await _repository.DeletePizza(id);
        }

        public async Task<List<PizzaDto?>> GetAllPizzas()
        {
            List<PizzaDto?> pizzas = (await _repository.GetAllPizzas()).Select(p => PizzaToDto(p)).ToList();
            return pizzas;
        }

        public async Task<PizzaDto?> GetPizza(int id)
        {
            PizzaDto? pizza = PizzaToDto(await _repository.GetPizza(id));
            return pizza;
        }

        public async Task<PizzaDto?> UpdatePizza(int id, PizzaDto newPizzaDto)
        {
            Pizza? newPizza = DtoToPizza(newPizzaDto);
            if (newPizza == null) return null;
            PizzaDto? pizza = PizzaToDto(await _repository.UpdatePizza(id, newPizza));
            return pizza;
        }
    }
}
