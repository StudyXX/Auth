using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ids4Services
{
    public class IdentityServices
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
