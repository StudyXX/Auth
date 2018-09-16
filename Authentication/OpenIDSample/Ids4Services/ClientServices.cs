using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ids4Services
{
    public class ClientServices
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //客户端授权模式
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes =GrantTypes.ClientCredentials,
                 
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("pwd".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1","api2" }
                },
                //密码模式
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("pwd".Sha256())
                    },
                    AllowedScopes = { "api1","api2","api2.read" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("pwd".Sha256())
                    },

                    RedirectUris           = { "http://localhost:2712/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:2712/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                }
        };
        }
    }
}
