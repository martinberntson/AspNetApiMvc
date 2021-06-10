using Microsoft.AspNetCore.Authorization;

namespace MusicMvcAndApi.Security.Services
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            Policy = "BasicAuthentication";
        }
    }
}
