using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicMvcAndApi.Security.Services
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            )
            : base(options, logger, encoder, clock) { }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-Authenticate", "Basic");
            if (!Request.Headers.ContainsKey("Authorization")) return Task.FromResult(AuthenticateResult.Fail("Auth.Header Missing"));

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader)) return Task.FromResult(AuthenticateResult.Fail("Auth.Code not properly formatted"));

            var authBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));
            var authSplit = authBase64.Split(Convert.ToChar(":"), 2);
            var authUsername = authSplit[0];
            var authPassword = authSplit[1].Length > 1 ? authSplit[1] : throw new Exception("Unable to get password");

            if (authUsername != "guest" || authPassword != "password") return Task.FromResult(AuthenticateResult.Fail("incorrect username or password"));

            var authenticatedUser = new Security.Model.AuthenticatedUser("BasicAuthentication", true, "guest");
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(authenticatedUser));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }
    }
}
