namespace WebAppMVC.Models
{
    public class FakeProRepos : IProductRepos
    {
        public IQueryable<Product> Products => new List<Product>{
            new Product { Name = "Valleyball", Price = 25},
            new Product { Name = "Shoes", Price = 145},
            new Product { Name = "T-shift", Price = 125},

            }.AsQueryable<Product>();
    }
}
