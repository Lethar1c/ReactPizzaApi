namespace ReactPizza.WebApi.Pizzas.Dtos
{
    public class SizeDto
    {
        public int Diameter { get; set; }
        public decimal Price { get; set; }
        public SizeDto(int diameter, decimal price)
        {
            Diameter = diameter;
            Price = price;
        }
    }
}
