using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UgadayApp.Pages
{
    public class UgadayModel : PageModel
    {
        public string Msg { get; set; } = "";
        public int Val { get; set; }
        public int UserNum { get; set; } 

        public void Rnd(int num)
        {
            Random random = new Random();
            Val = random.Next(1, 10);
            UserNum = num;

        }

        public void OnGet()
        {
            Msg = "Welcome!";
        }

        public void OnPost(int usernum)
        {
            Rnd(usernum);
        }
    }
}
