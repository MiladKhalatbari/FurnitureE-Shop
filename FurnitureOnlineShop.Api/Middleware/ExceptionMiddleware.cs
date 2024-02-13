using FurnitureOnlineShop.Api.Models;
using FurnitureOnlineShop.Application.Contracts;
using FurnitureOnlineShop.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;
namespace FurnitureOnlineShop.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomProblemDetails problem;
        switch (ex)
        {
            case NotFoundException notFound:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomProblemDetails()
                {
                    Type = nameof(NotFoundException),
                    Status = (int)statusCode,
                    Title = notFound.Message,
                    Detail = notFound.InnerException?.ToString(),
                };
                break;
            case BadRequestException badRequest:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails()
                {
                    Type = nameof(BadRequestException),
                    Status = (int)statusCode,
                    Title = badRequest.Message,
                    Detail = badRequest.InnerException?.ToString(),
                    Errors = badRequest.ValidationErrors
                };
                break;
            default:
                problem = new CustomProblemDetails()
                {
                    Type = nameof(NotFoundException),
                    Status = (int)statusCode,
                    Title = ex.Message,
                    Detail = ex.StackTrace
                };
                break;
        }
        httpContext.Response.StatusCode = (int)statusCode;
        var logMessage = JsonConvert.SerializeObject(problem);
        _logger.LogError(logMessage);
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}
