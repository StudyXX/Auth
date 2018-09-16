using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenIDSample
{
    public class MyResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = TestUsers.Users.FirstOrDefault(item=>item.Username=="aaa");
            context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password,user.Claims);
            return Task.CompletedTask;
        }
    }
}
