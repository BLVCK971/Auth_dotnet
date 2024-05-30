using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters;

public class MyLogging : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Filter Executed Before");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Filter Executed After");
    }
}
