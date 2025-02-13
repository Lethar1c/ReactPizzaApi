﻿using ReactPizza.DataAccess.Models;

namespace ReactPizza.DataAccess.Repositories
{
    public interface IUserRepository
    {
        public Task<User> Add(User user);
        public Task<User?> Update(int id, User user);
        public Task Delete(int id);
        public Task<User?> Get(int id);
        public Task<List<User>> GetAll();
    }
}
