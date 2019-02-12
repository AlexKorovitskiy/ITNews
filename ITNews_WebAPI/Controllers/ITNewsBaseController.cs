using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITNews_WebAPI.Controllers
{
    public class ITNewsBaseController : Controller
    {
        protected int UserId { get; private set; }

        protected bool CurrentUserHasRole(string role)
        {
            var currentRoles = User?.Claims?.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;
            if (string.IsNullOrEmpty(currentRoles))
            {
                return false;
            }
            var rolesArray = currentRoles.Split(',');
            foreach (var item in rolesArray)
            {
                if (item == role)
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idString = User?.Claims?.FirstOrDefault(x => x.Type == ITNews.AuthOptions.DefaultIdClaimType)?.Value;
            int id = 0;
            if (!string.IsNullOrEmpty(idString))
            {
                int.TryParse(idString, out id);
            }
            UserId = id;
            base.OnActionExecuting(context);
        }
    }
}