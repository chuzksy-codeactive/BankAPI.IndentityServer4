using IdentityServer4.Models;
using System.Collections.Generic;

namespace Bank.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("BankAPI", "Customer API for Bank")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "BankAPI" }
            }
        };
    }
}
