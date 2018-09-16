using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;

namespace Ids4Services
{
    public class MyResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {           
            var user = UserServices.GetUsers().FirstOrDefault(item => item.Username == context.UserName);
            context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password, user.Claims);
            return Task.CompletedTask;
        }
    }
}
