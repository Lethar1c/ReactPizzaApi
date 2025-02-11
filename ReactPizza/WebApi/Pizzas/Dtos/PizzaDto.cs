namespace ReactPizza.WebApi.Pizzas.Dtos
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Rating;
        public List<Tuple<int, decimal>> Sizes { get; set; } = [];
        public List<Tuple<int, string>> Types { get; set; } = [];
    }
}
