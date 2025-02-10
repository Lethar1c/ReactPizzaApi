namespace ReactPizza.DataAccess
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public Category() { }
        public Category(string name)
        {
            Name = name;
        }
        public List<Pizza> Pizzas { get; set; } = null!;
    }
}
