using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppRazor.Pages
{
    public class LessonModel : PageModel
    {
        //[BindProperty]
        //public string Username { get; set; } = "";
        //[BindProperty]
        //public int Age { get; set; }
        [BindProperty]
        public Product product { get; set; } = new Product("Asus", 21000, "China Computers");
        public string Msg { get; private set; } = "Добавить товар";

        public void OnPost()
        {
            Msg = $"Добавлен новый товар: {product.Name}, {product.Price}, {product.Company}";
        }

    }

    public record class Product (string Name, int Price, string Company);
}
