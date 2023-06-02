using LetsPack.DTOs;

namespace LetsPack.Interfaces
{
    public interface IItemService
    {
        Task AddItem(ItemInput input);
        Task EditItem(ItemInput input, int id);
        Task RemoveItem(int id);
        Task<ItemInput> GetItemById(int id, string userName);
        Task<ItemInput> GetAllItems(string userName);
    }
}
