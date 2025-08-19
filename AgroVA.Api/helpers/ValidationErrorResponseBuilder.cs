using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AgroVA.Api.helpers;

public static class ValidationErrorResponseBuilder
{
    public static BadRequestObjectResult BadRequest(HttpContext context, ModelStateDictionary modelState)
    {
        var errors = modelState
            .Where(entry => entry.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).AsEnumerable()
            );

        return BadRequest(context, errors);
    }

    public static BadRequestObjectResult BadRequest(HttpContext context, IDictionary<string, IEnumerable<string>> errors)
    {
        var response = new
        {
            type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            title = "One or more validation errors occurred.",
            status = StatusCodes.Status400BadRequest,
            errors = errors,
            traceId = context.TraceIdentifier
        };

        return new BadRequestObjectResult(response);
    }

    public static BadRequestObjectResult BadRequest(HttpContext context, string key, string message)
    {
        var errors = new Dictionary<string, IEnumerable<string>>
            {
                { key, new[] { message } }
            };

        return BadRequest(context, errors);
    }
}