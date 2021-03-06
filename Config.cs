﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanCinema
{
    using System.Collections.Generic;
    using IdentityServer4.Models;

    namespace AuthServer
    {
        public class Config
        {
            public static IEnumerable<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
            }

            public static IEnumerable<ApiResource> GetApiResources()
            {
                return new List<ApiResource>
            {
                new ApiResource("resourceapi", "Resource API")
                {
                    Scopes = {new Scope("api.read")}
                }
            };
            }

            public static IEnumerable<Client> GetClients()
            {
                return new[]
                {
                new Client {
                    RequireConsent = false,
                    ClientId = "react_spa",
                    ClientName = "React SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api.read" },
                    RedirectUris = {"http://localhost:3000/auth-callback"},
                    PostLogoutRedirectUris = {"http://localhost:3000/"},
                    AllowedCorsOrigins = {"http://localhost:3000"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                }
            };
            }
        }
    }
}
