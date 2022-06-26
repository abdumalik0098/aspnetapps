using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepos repos;
        public ProductController(IProductRepos repo)
        {
            repos = repo;
        }

        public ViewResult List() => View(repos.Products);
    }
}
