﻿namespace ReactPizza.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string HashedPassword { get; set; } = "";
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public User() { }
    }
}
