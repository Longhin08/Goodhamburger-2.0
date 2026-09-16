using GoodHamburgerAdmin.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Infrastructure;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Item?> GetByIdAsync(int id) =>
       await _context.Itens.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<List<Item>> GetAllAsync() =>
        await _context.Itens.ToListAsync();

    public async Task AddAsync(Item item) =>
        await _context.Itens.AddAsync(item);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
