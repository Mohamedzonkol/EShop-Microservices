using Marten.Schema;

namespace CatlogApi.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync(token: cancellation))
            {
                return;
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Catalog 1",
                Description = "Catalog 1 Description",
                ImageFile = "Catalog1.jpg",
                Price = 100,
            };
            session.Store<Product>(GetProduct());
            await session.SaveChangesAsync(cancellation);

        }

        private static IEnumerable<Product> GetProduct() => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Catalog 1",
                Category = ["Smart phone"],
                Description = "Catalog 1 Description",
                ImageFile = "Catalog1.jpg",
                Price = 100,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Catalog 2",
                Category = ["Smart phone", "Smart home"],
                Description = "Catalog 2 Description",
                ImageFile = "Catalog2.jpg",
                Price = 200,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Catalog 3",
                Category = ["Smart phone", "Smart home"],
                Description = "Catalog 3 Description",
                ImageFile = "Catalog3.jpg",
                Price = 300,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Catalog 4",
                Category = ["zz", "aa"],
                Description = "Catalog 4 Description",
                ImageFile = "Catalog4.jpg",
                Price = 400,
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Catalog 5",
                Category = ["x", "z"],
                Description = "Catalog 5 Description",
                ImageFile = "Catalog5.jpg",
                Price = 500,
            },
        };


    }
}
