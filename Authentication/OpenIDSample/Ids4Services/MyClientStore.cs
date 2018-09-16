using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Ids4Services
{
    public class MyClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client=ClientServices.GetClients().FirstOrDefault(item => item.ClientId == clientId);
            return Task.FromResult(client);
        }
    }
}
