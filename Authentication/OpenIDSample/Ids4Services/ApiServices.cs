using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Ids4Services
{
    public class ApiServices
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API"),
                new ApiResource{
                    Scopes={
                        new Scope{
                            Name="api2"
                        },
                        new Scope{
                            Name="api2.read"
                        }
                    }
                }
            };
        }
    }
}
