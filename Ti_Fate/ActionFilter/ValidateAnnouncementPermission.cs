using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service;
using Ti_Fate.Extensions;

namespace Ti_Fate.ActionFilter
{
    public class ValidateAnnouncementPermission : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HasPermission(context))
            {
                context.Result = new RedirectToActionResult("PermissionError", "PermissionError", null);
            }
            base.OnActionExecuting(context);
        }

        private static bool HasPermission(ActionExecutingContext context)
        {
            var permission = context.HttpContext.Session.GetObject<LoginSession>("LoginSession").Permission;
            var announcementType = context.ActionArguments["announcementType"].ToString();
            return PermissionsService.HasAnnouncementPermission(permission, announcementType);
        }
    }

}
