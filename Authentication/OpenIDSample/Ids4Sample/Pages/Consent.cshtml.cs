using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ids4Sample.Pages
{
    public class ConsentModel : PageModel
    {
        private readonly IIdentityServerInteractionService _interaction;

        public ConsentModel(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public IActionResult OnGet(string returnUrl)
        {
            var request = _interaction.GetAuthorizationContextAsync(returnUrl);
            _interaction.GrantConsentAsync(request.Result, new IdentityServer4.Models.ConsentResponse
            {
                RememberConsent = true,
                ScopesConsented = request.Result.ScopesRequested
            });
            return Redirect(returnUrl);
        }
    }
}