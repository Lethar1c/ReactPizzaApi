namespace ReactPizza.DataAccess
{
    public class Size
    {
        public int Id { get; set; }
        public int Cantimeters { get; set; }
        public decimal Price { get; set; }
        public Size() { }
        public Size(int cantimeters, decimal price)
        {
            Cantimeters = cantimeters;
            Price = price;
        }
        public List<Pizza> Pizzas { get; set; } = null!;

    }
}
