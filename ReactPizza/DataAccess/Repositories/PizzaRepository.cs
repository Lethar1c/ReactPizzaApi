﻿using Microsoft.EntityFrameworkCore;
using ReactPizza.DataAccess.Models;

namespace ReactPizza.DataAccess.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private ApplicationContext _context;
        public PizzaRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return _context.Pizzas.Include(p => p.Types).Include(p => p.Sizes).OrderBy(p => p.Id).Last();
        }
        public async Task<Pizza?> GetPizza(int id)
        {
            Pizza? pizza = await _context.Pizzas.Include(p => p.Types).Include(p => p.Sizes).FirstOrDefaultAsync(pizza => pizza.Id == id);
            return pizza;
        }
        public async Task<List<Pizza>> GetAllPizzas()
        {
            return await _context.Pizzas.Include(p => p.Types).Include(p => p.Sizes).ToListAsync();
        }
        public async Task<Pizza?> UpdatePizza(int id, Pizza newPizza)
        {
            Pizza? pizza = await _context.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id == id);
            if (pizza == null)
            {
                return null;
            }
            pizza.Sizes = newPizza.Sizes;
            pizza.Description = newPizza.Description;
            pizza.Rating = newPizza.Rating;
            pizza.Name = newPizza.Name;
            pizza.Types = newPizza.Types;
            await _context.SaveChangesAsync();
            return pizza;
        }
        public async Task DeletePizza(int id)
        {
            Pizza? pizza = await _context.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id == id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();
            }
        }
    }
}
