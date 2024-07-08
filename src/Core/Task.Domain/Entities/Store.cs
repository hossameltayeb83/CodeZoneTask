namespace Task.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public IReadOnlyCollection<Item> Items { get; set; }
    }
}
