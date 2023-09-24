using System;
using System.Net;
using chapter_4.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace chapter_4.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttributes : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var UserId = context.HttpContext.Items["UserId"]!;
            if (UserId == null)
            {
                throw new NotConnectedException("An error occured during login");
            }

        }
    }
}

