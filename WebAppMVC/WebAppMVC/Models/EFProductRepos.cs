using System.Collections.Generic;
using System.Linq;

namespace WebAppMVC.Models
{
    public class EFProductRepos : IProductRepos
    {
        private ApplicationDbContext context;

        public EFProductRepos(ApplicationDbContext cxt)
        {
            context = cxt;
        }

        public IQueryable<Product> Products => context.Products;
    }
}
