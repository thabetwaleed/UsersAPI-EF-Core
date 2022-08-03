using Microsoft.AspNetCore.Mvc.Filters;

namespace UsersAPI.Fillters
{
    public class Roles : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.
                FirstOrDefault(c => c.Key == "Role").Value != "Admin")
            {
                throw new Exception("You are ROLE is not Admin");
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }




    }
}