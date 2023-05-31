using LetsPack.Data;
using LetsPack.Models;
using Microsoft.AspNetCore.Identity;

namespace LetsPack.Services
{
    public class DatabaseService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<User> _userManager;

        public DatabaseService(ApplicationDbContext ctx, UserManager<User> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }
        public async Task Seed()
        {
            var testUser = new User()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                UserName = "Test",
                Items = new List<Item>()
            };
            await _userManager.CreateAsync(testUser, "Passw0rd!");
            var itemList = new List<Item>()
            {
                new Item()
                {
                    Name= "Test",
                    Description= "Test",
                    Category= "Test",
                    Price= 1,
                    Store="Test",
                    User= testUser
                },
                new Item()
                {
                    Name= "Test",
                    Description= "Test",
                    Category= "Test",
                    Price= 1,
                    Store="Test",
                    User= testUser
                },
                new Item()
                {
                    Name= "Test",
                    Description= "Test",
                    Category= "Test",
                    Price= 1,
                    Store="Test",
                    User= testUser
                },
                new Item()
                {
                    Name= "Test",
                    Description= "Test",
                    Category= "Test",
                    Price= 1,
                    Store="Test",
                    User= testUser
                }
            };
            await _ctx.AddRangeAsync(itemList);
            await _ctx.SaveChangesAsync();
        }
        public async Task Recreate()
        {
            await _ctx.Database.EnsureDeletedAsync();
            await _ctx.Database.EnsureCreatedAsync();
        }
        public async Task CreateIfNotExist()
        {
            await _ctx.Database.EnsureCreatedAsync();
        }
        public async Task RecreateAndSeed()
        {
            await Recreate();
            await Seed();
        }
        public async Task CreateAndSeedIfNotExist()
        {
            bool createdDatabase = await _ctx.Database.EnsureCreatedAsync();
            if (createdDatabase) await Seed();
        }
    }
}
