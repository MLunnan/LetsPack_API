using Microsoft.AspNetCore.Identity;

namespace LetsPack.Models
{
    public class User : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}
