using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WWMS.BAL.Authentications
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _roles;
        public PermissionAuthorizeAttribute(params string[] roles)
        {
            this._roles = roles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            CheckAuthenticatedUserRole(context);
        }

        private void CheckAuthenticatedUserRole(AuthorizationFilterContext context)
        {
            if (context == null) return;

            var httpContext = context.HttpContext;

            if (httpContext == null) return;

            var user = httpContext.User;

            if (user == null) return;

            var identity = user.Identity;

            if (identity == null) return;

            if (!identity.IsAuthenticated) 
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            var roleClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("role", StringComparison.CurrentCultureIgnoreCase));

            if (roleClaim == null) return;

            if (this._roles.FirstOrDefault(x => x.Trim().ToLower().Equals(roleClaim.Value.Trim().ToLower())) == null)
            {
                context.Result = new ObjectResult("Forbidden") { StatusCode = 403, Value = "You are not allowed to access this function!" };
            }
        }
    }
}
