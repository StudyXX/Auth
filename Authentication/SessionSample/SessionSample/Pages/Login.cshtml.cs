using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SessionSample.Pages
{
    public class LoginModel : MyPage
    {
        public IActionResult OnGet()
        {
            if (IsLogin)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("UserId", Guid.NewGuid().ToString());
            return RedirectToPage("/Index");
        }
    }
}