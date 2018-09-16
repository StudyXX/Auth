using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;

namespace Ids4Services
{
    public class MyProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = UserServices.GetUsers().FirstOrDefault(item => item.SubjectId == context.Subject.GetSubjectId());
            context.AddRequestedClaims(user.Claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = UserServices.GetUsers().FirstOrDefault(item => item.SubjectId == context.Subject.GetSubjectId());
            context.IsActive = user?.IsActive == true;
            return Task.CompletedTask;
        }
    }
}
