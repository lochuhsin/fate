using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Extensions;

namespace Ti_Fate.ActionFilter
{
    public class ValidatePermissionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HasPermission(context))
            {
                context.Result = new RedirectToActionResult("PermissionError", "PermissionError", null);
            }
            base.OnActionExecuting(context);
        }

        private bool HasPermission(ActionExecutingContext context)
        {
            var permission = context.HttpContext.Session.GetObject<LoginSession>("LoginSession").AccountPermission;
            var announcementType = context.ActionArguments["announcementType"].ToString();
            return permission.HasAnnouncementPermission(announcementType);
        }
    }

}
