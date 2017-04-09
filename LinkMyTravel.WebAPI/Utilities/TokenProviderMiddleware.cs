using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace LinkMyTravel.WebAPI.Utilities
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;

        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            if (!VarifyToken(context))
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Authentication Error: Token is Missing.");
            }

            return _next(context);
        }

        private bool VarifyToken(HttpContext context)
        {
            var xTokenVal = context.Request.Headers["X-Token"];
            if (xTokenVal.Count == 0 || (((String)xTokenVal).ToLower() != "test123"))
            {
                context.Response.StatusCode = 400;
                return false;
            }

            return true;
        }
    }
}
