using AppRazorEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<User> Users { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Users = context.Users.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}