using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OpenIDSample.Pages
{
    public class LoginModel : PageModel
    {
        private IIdentityServerInteractionService _interaction;
        private IClientStore _clientStore;
        public LoginModel(IIdentityServerInteractionService interaction,IClientStore clientStore)
        {
            _interaction = interaction;
            _clientStore = clientStore;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Request.Query.TryGetValue("returnUrl", out StringValues strVal);
            var context=_interaction.GetAuthorizationContextAsync(strVal);
            AuthenticationProperties props = new AuthenticationProperties {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
            };
            var user = TestUsers.Users.FirstOrDefault(item => item.Username == "aaa");
            HttpContext.SignInAsync(user.SubjectId, user.Username, props);
            Redirect(strVal);
        }
    }
}