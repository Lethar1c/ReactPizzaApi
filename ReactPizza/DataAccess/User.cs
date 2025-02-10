namespace ReactPizza.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string HashedPassword { get; set; } = "";
        public int RoleId { get; set; }
        public Role Role { get; set; } = new Role("user");
        public User() { }
    }
}
