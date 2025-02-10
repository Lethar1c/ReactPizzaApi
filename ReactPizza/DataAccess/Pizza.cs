namespace ReactPizza.DataAccess
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Rating;
        public List<Size> Sizes { get; set; } = [];
        public List<Type> Types { get; set; } = [];
        public Pizza() { }

    }
}
