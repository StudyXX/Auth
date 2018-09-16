using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenIDSample
{
    public class ClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)

        {
            return Task.FromResult(new Client()
            {
                ClientId = "openid",
                ClientName = "OpenIDTest",
                
                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                RedirectUris = { "http://localhost:11571/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:11571/signout-callback-oidc" },
                ClientSecrets = {
                    new Secret("pwd".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                },
                AllowOfflineAccess=true
            });
        }
    }
}
