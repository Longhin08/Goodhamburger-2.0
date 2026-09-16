using GoodHamburgerAdmin.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Infrastructure;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(int id);
    Task<List<Item>> GetAllAsync();
    Task AddAsync(Item item);
    Task SaveChangesAsync();

}
