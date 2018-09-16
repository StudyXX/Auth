using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SessionSample.Pages
{
    public class MyPage:PageModel
    {
        protected bool IsLogin
        {
            get
            {
                string userId = null;
                if (HttpContext.Session.TryGetValue("UserId", out byte[] bytes))
                {
                    userId = Encoding.UTF8.GetString(bytes);
                }
                return !string.IsNullOrWhiteSpace(userId);
            }
        }
    }
}
