using System;
using System.Linq;
using System.Web.Http;
using System.Security.Claims;
using System.Web.Http.Controllers;

namespace bookstore.controllers
{
    public class HasScope: AuthorizeAttribute
    {
        private const string ClaimType = "";
        private readonly string[] _scopes;

        public HasScope(params string[] scopes)
        {
            if (scopes == null) new ArgumentNullException(nameof(scopes)).LogBeforeThrow();
            _scopes = scopes;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var grantedScopes = ClaimsPrincipal.Current.FindAll(ClaimType).Select(c => c.Value).ToList();
            return _scopes.All(s => grantedScopes.Contains(s));
        }
    }
}
