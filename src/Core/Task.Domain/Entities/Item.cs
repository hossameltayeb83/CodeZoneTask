namespace Task.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public IReadOnlyCollection<Store> Stores { get; set; }
    }
}
