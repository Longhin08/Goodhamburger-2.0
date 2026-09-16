using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure.Services;

public interface IItemService
{
    Task<Item?> ObterPorIdAsync(int id);
    Task<List<Item>> ObterTodosAsync();
    Task<Item> CriarItemAsync(Item item);
}