using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SessionSample.Pages
{
    public class IndexModel : MyPage
    {
        public IActionResult OnGet()
        {
            if (!IsLogin)
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }
    }
}