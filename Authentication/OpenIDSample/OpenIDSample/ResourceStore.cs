using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenIDSample
{
    public class ResourceStore : IResourceStore
    {
        private IEnumerable<ApiResource> _apiResources = new ApiResource[] {
                new ApiResource("api", "Api Values")
        };
        private IEnumerable<IdentityResource> _identityResources = new IdentityResource[] {
            new IdentityResources.OpenId(),
          new IdentityResources.Profile()
    };

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var api = _apiResources.FirstOrDefault(item => item.Name == name);
            return Task.FromResult(api);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var apis = _apiResources.Where(item => scopeNames.Contains(item.Name));
            return Task.FromResult(apis);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var result = _identityResources.Where(item => scopeNames.Contains(item.Name));
            return Task.FromResult(result);
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            return Task.FromResult(new Resources(_identityResources, _apiResources));
        }
    }
}
