using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace refactor_me.Infrastructure
{
    public class ServerCorsPolicy : ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;

        public ServerCorsPolicy(IEnumerable<string> corsSites)
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                SupportsCredentials = true
            };

            // Add allowed origins.
            foreach (var site in corsSites)
            {
                _policy.Origins.Add(site);
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}