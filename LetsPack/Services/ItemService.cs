using LetsPack.Data;
using LetsPack.DTOs;
using LetsPack.Models;
using Microsoft.AspNetCore.Identity;

namespace LetsPack.Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<User> _userManager;
        public ItemService(ApplicationDbContext ctx, UserManager<User> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task AddItem(ItemInput input)
        {
            Item newItem = new Item();
            var user = await _userManager.FindByEmailAsync(input.UserName!);
            if(user != null)
            {
                newItem.Name = input.Name;
                newItem.Description = input.Description;
                newItem.Category = input.Category;
                newItem.Store = input.Store;
                newItem.Price = input.Price;
                newItem.User = user;

                await _ctx.items!.AddAsync(newItem);
                await _ctx.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No user with email: " + input.UserName + " could be found");
            }
        }
        public async Task EditItem(ItemInput input, int id)
        {
            try
            {
                var item = await _ctx.items!.FindAsync(id);
                if(item == null)
                {
                    throw new Exception($"No item with id: {id} could be found");
                }
                item.Name = input.Name;
                item.Description = input.Description;
                item.Category = input.Category;
                item.Store = input.Store;
                item.Price = input.Price;

                _ctx.items.Update(item);
                await _ctx.SaveChangesAsync();
            }
            catch
            {
                throw new Exception($"No item with id: {id} could be found");
            }
        }
        public async Task RemoveItem(int id)
        {
            var item = await _ctx.items!.FindAsync(id);
            if(item != null)
            {
                _ctx.items.Remove(item);
                await _ctx.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No item with id: {id} could be found");
            }
        }
    }
}
