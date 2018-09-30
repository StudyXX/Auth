using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieSample2.Pages.Account
{
public class LoginModel : PageModel
{
    [BindProperty]
    public IDictionary<string, string> Schemes { get; set; } = new Dictionary<string, string>();

    [BindProperty]
    public string RedirectToUrl { get; set; }

    IAuthenticationSchemeProvider _authenticationSchemeProvider;

    //构造函数注入方式获取IAuthenticationSchemeprovider实例
    public LoginModel(IAuthenticationSchemeProvider authenticationSchemeProvider)
    {
        //也可以通过从服务中查找的方式获取IAuthenticationSchemeprovider实例
        //_authenticationSchemeProvider = (IAuthenticationSchemeProvider)HttpContext.RequestServices.GetService(typeof(IAuthenticationSchemeProvider));
        _authenticationSchemeProvider = authenticationSchemeProvider;
    }
    public async Task OnGetAsync(string ReturnUrl)
    {
        RedirectToUrl = ReturnUrl;
        var authenticationSchemes = await _authenticationSchemeProvider.GetAllSchemesAsync();
        foreach (var item in authenticationSchemes)
        {
            Schemes.Add(item.Name, item.DisplayName??item.Name);
        }
    }

    public IActionResult OnPost(string scheme,string redirectUrl)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,scheme)
        };
            
        var claimsIdentity = new ClaimsIdentity(claims, scheme);
        HttpContext.SignInAsync(scheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties(new Dictionary<string, string> {
            { "测试","纯演示用"}
        }));
        return LocalRedirect(redirectUrl);
    }
}
}