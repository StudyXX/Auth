using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace ClientCredAppSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        static async void Test()
        {
            var diso = await DiscoveryClient.GetAsync("http://localhost:2409");
            if (diso.IsError)
            {
                Console.WriteLine(diso.Error);
                return;
            }
            var tokenClient = new TokenClient(diso.TokenEndpoint, "mvc", "pwd");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
            //var tokenClient = new TokenClient(diso.TokenEndpoint, "ro.client", "pwd");
            //var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);

            var httpClient = new HttpClient();
            httpClient.SetBearerToken(tokenResponse.AccessToken);
            var response =await httpClient.GetAsync("http://localhost:2712/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content =await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }

        }
    }
}
