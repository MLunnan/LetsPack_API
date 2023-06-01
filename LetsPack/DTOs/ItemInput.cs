using LetsPack.Models;

namespace LetsPack.DTOs
{
    public class ItemInput
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
        public string? Store { get; set; }
        public string UserName { get; set; }
    }
}
