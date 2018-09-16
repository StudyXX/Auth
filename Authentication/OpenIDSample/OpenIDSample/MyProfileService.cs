using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenIDSample
{
    public class MyProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = TestUsers.Users.FirstOrDefault(item => item.SubjectId == context.Subject.GetSubjectId());
            context.AddRequestedClaims(user.Claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = TestUsers.Users.FirstOrDefault(item => item.SubjectId == context.Subject.GetSubjectId());
            context.IsActive =user?.IsActive == true;
            return Task.CompletedTask;
        }
    }
}
