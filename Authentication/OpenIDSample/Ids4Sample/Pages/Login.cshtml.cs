using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Ids4Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ids4Sample.Pages
{
    public class LoginModel : PageModel
    {
        IIdentityServerInteractionService _interaction;

        public LoginModel(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public void OnGet()
        {
        }

        public void OnPostAsync(string userName,string userPwd,[FromQuery]string returnUrl)
        {
            //var context=await _interaction.GetAuthorizationContextAsync(returnUrl);
            var user = UserServices.GetUsers().FirstOrDefault(item => item.Username == userName);
            AuthenticationProperties props = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
            };
            HttpContext.SignInAsync(user.SubjectId,user.Username, props);
            Redirect(returnUrl);
        }
    }
}