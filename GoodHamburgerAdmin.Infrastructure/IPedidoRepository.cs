using GoodHamburgerAdmin.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHamburgerAdmin.Infrastructure;

public interface IPedidoRepository
{
    Task<Pedido?> GetByIdAsync(int id);
    Task<List<Pedido>> GetAllAsync();
    Task AddAsync(Pedido pedido);
    Task SaveChangesAsync();
}
