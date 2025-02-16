namespace ReactPizza.DataAccess.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = null!;
        public Role() { }
        public Role(string name)
        {
            Name = name;
        }
    }
}
