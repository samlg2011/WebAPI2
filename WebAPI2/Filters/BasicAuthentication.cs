using System;using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebAPI2.Models;

namespace WebAPI2.Filters
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string contextString = actionContext.Request.Headers.Authorization.Parameter;
                string tokenString = Encoding.UTF8.GetString(Convert.FromBase64String(contextString));

                string token = tokenString.Split(':')[0];

                if(!ApiUser.ValidateToken(token))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    // put user detail in http context
                    ApiUser user = ApiUser.GetUserDetail(token);
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(user), new string[] { });
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}