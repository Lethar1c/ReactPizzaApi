namespace ReactPizza.WebApi.Pizzas.Dtos
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Rating;
        public List<SizeDto> Sizes { get; set; } = [];
        public List<TypeDto> Types { get; set; } = [];
    }
}
