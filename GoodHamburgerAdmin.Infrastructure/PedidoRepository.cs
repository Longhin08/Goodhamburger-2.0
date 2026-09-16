using GoodHamburgerAdmin.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Infrastructure;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido?> GetByIdAsync(int id) =>
        await _context.Pedidos
            .Include(p => p.Itens)
            .ThenInclude(pi => pi.Item)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Pedido>> GetAllAsync() =>
        await _context.Pedidos
            .Include(p => p.Itens)
            .ThenInclude(pi => pi.Item)
            .ToListAsync();

    public async Task AddAsync(Pedido pedido) =>
        await _context.Pedidos.AddAsync(pedido);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
