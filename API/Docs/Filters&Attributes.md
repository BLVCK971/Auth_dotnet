# Filters & Attributes

- Method for the API launch after a request before and after a specific actions or a specific controller
- Middleware =\= Filters & Attributes : Middleware => All Requests
## Source 
https://youtu.be/ZvxXK0AuFIQ?si=12T7zZV0ONimzciS

## Methods

- Filter : Every requests
- Attributes : One or more selected requests
- + async

## Examples in this
### Filter
#### Filter/MyLogging.cs
```cs
public class MyLogging : IActionFilter
{
	
	public void OnActionExecuting(ActionExecutingContext context){

		Console.WriteLine("Filter Executed Before");

	}
	public void OnActionExecuted(ActionExecutedContext context){
		
		Console.WriteLine("Filter Executed After");
	}
}
```
#### Services (builder)
```cs
builder.Services.AddControllers(opt =>
        {
        opt.Filters.Add<MyLogging>();
        //  opt.Filters.Add(new MyLogging());
});
```
### Attribute
#### Filter/MyLoggingAttribute.cs
```cs
public class MyLoggingAttribute : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Attribute Executed Before explicit {_callerName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Attribute Executed After explicit {_callerName}");
    }
}
```
#### Controllers/SalutController.cs
```cs
    [MyLogging("Test Attributes")]
```
### Async

#### Filter/MyLoggingAsync.cs
```cs
public class MyLoggingAsync : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next
    )
    {
        Console.WriteLine($"Async Before the request");
        await next();
        Console.WriteLine($"Async After the request");
    }
}
```
#### Controllers/SalutController.cs
```cs
    [MyLoggingAsync("Test Async")]
```

