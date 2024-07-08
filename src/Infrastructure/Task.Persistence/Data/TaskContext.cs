using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task.Domain.Entities;

namespace Task.Persistence.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public TaskContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FakeData.Init(1253, 10);
            modelBuilder.Entity<Store>().HasData(FakeData.Stores.Take(FakeData.Stores.Count / 2));
            modelBuilder.Entity<Item>().HasData(FakeData.Items.Take(FakeData.Items.Count / 2));
            modelBuilder.Entity<StoreItem>().HasData(FakeData.StoreItems.Take(FakeData.StoreItems.Count / 2));
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public static class FakeData
        {
            public static List<Store> Stores { get; set; } = new();
            public static List<Item> Items { get; } = new();
            public static List<StoreItem> StoreItems { get; } = new();

            public static void Init(int seed, int count)
            {
                var faker = new Faker();

                var storeId = FakeData.Stores.Count + 1;
                var storeFaker = new Faker<Store>()
                   .UseSeed(seed)
                   .RuleFor(b => b.Image, _ => $"Images\\Stores\\{storeId}.jpg")
                   .RuleFor(b => b.Id, _ => storeId++)
                   .RuleFor(b => b.Name, f => f.Company.CompanyName());
                var stores = storeFaker.Generate(count).GroupBy(c => c.Id).Select(c => c.FirstOrDefault()).ToList();
                FakeData.Stores.AddRange(stores);

                var itemId = FakeData.Items.Count + 1;
                var itemFaker = new Faker<Item>()
                   .UseSeed(seed)
                   .RuleFor(b => b.Image, _ => $"Images\\Items\\{itemId}.jpg")
                   .RuleFor(b => b.Id, _ => itemId++)
                   .RuleFor(b => b.Name, f => f.Commerce.ProductName());
                var items = itemFaker.Generate(count).GroupBy(c => c.Id).Select(c => c.FirstOrDefault()).ToList();
                FakeData.Items.AddRange(items);

                var storeItemsFaker = new Faker<StoreItem>()
                   .UseSeed(seed)
                   .RuleFor(b => b.StoreId, f => f.PickRandom(stores).Id)
                   .RuleFor(b => b.ItemId, f => f.PickRandom(items).Id)
                   .RuleFor(b => b.Quantity, f => f.Random.Int(1, 100));
                var storeItems = storeItemsFaker.Generate(count * 2).GroupBy(c => new { c.StoreId, c.ItemId }).Select(c => c.FirstOrDefault()).ToList();
                FakeData.StoreItems.AddRange(storeItems);
            }
        }
    }
}

