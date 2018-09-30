using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CookieSample2
{
    public class MyCookieManager : ICookieManager
    {
        public void AppendResponseCookie(HttpContext context, string key, string value, CookieOptions options)
        {
            context.Response.Cookies.Append(key, value, options);
        }

        public void DeleteCookie(HttpContext context, string key, CookieOptions options)
        {
            context.Response.Cookies.Delete(key, options);
        }

        public string GetRequestCookie(HttpContext context, string key)
        {
            return context.Request.Cookies[key];
        }
    }
}
