using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppRazor.Pages
{
    public class MypageModel : PageModel
    {
        public string Hello { get; }
        public MypageModel()
        {
            Hello = "This is Mypage Model";
        }

        public string datePrint() => DateTime.Now.ToShortDateString();

        public string Message { get; private set; } = "";
        //public void OnGet(string name, int age)
        //{
        //    Message = $"Hello {name}, Age: {age}";

        //}

        public string[] People { get; private set; } = Array.Empty<string>();

        public void OnPost(string[] people)
        {
            People = people;
        }
    }
}
