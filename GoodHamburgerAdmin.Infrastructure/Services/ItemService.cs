using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Item?> ObterPorIdAsync(int id) =>
        await _itemRepository.GetByIdAsync(id);

    public async Task<List<Item>> ObterTodosAsync() =>
        await _itemRepository.GetAllAsync();

    public async Task<Item> CriarItemAsync(Item item)
    {
        await _itemRepository.AddAsync(item);
        await _itemRepository.SaveChangesAsync();
        return item;
    }
}