namespace WebAppMVC.Models
{
    public interface IProductRepos
    {
        IQueryable<Product> Products { get; }
    }
}
