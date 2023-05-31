namespace LetsPack.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
        public string? Store { get; set; }
        public virtual User User { get; set; }
    }
}
