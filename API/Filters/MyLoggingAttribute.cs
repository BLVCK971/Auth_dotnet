using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class MyLoggingAttribute : Attribute, IActionFilter
{
    private readonly string _callerName;

    public MyLoggingAttribute(string callerName)
    {
        _callerName = callerName;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Attribute Executed Before explicit {_callerName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Attribute Executed After explicit {_callerName}");
    }
}
