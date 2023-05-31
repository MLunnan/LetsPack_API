using LetsPack.Data;
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

        public async Task AddItem()
    }
}
