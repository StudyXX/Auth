using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Ids4Services
{
    public class MyResourceStore : IResourceStore
    {
        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiReource = ApiServices.GetApiResources().FirstOrDefault(item => item.Name == name);
            return Task.FromResult(apiReource);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var apiResources = ApiServices.GetApiResources().Where(item => scopeNames.Contains(item.Name));
            return Task.FromResult(apiResources);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var identityResources = IdentityServices.GetIdentityResources().Where(item => scopeNames.Contains(item.Name));
            return Task.FromResult(identityResources);
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            return Task.FromResult(new Resources(IdentityServices.GetIdentityResources(), ApiServices.GetApiResources()));
        }
    }
}
