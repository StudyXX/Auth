using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieSample2.Pages.Admin
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}