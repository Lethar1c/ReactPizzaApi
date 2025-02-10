namespace ReactPizza.DataAccess
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = "user";
        public List<User> Users { get; set; } = null!;
        public Role() { }
        public Role(string name)
        {
            Name = name;
        }
    }
}
