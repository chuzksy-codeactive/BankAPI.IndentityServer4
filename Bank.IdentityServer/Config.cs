using IdentityServer4.Models;
using System.Collections.Generic;

namespace Bank.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> ApiResources => new[]
            {
            new ApiResource
            {
                Name = "BankAPI",
                DisplayName = "Bank API #1",
                Description = "Allow the application to access Bank API #1 on your behalf",
                Scopes = new List<string> {"bankapi.read", "bankapi.write"},
                ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("bankapi.read", "Customer API for Bank")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientName = "Bank of Nigeria",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "bankapi.read", "bankapi.write" }
            }
        };
    }
}
