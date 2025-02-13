﻿namespace ReactPizza.WebApi.Authenfication.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public RoleDto() { }
        public RoleDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
