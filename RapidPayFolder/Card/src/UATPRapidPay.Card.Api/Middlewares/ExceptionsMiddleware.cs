using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Api.Middlewares
{
    public class ExceptionsMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ApplicationException ex)
            {
                context.Response.StatusCode = 400;

                context.Response.Headers.Add("content-type", "application/json");

                string json = JsonSerializer.Serialize(new { ex.Message });

                await context.Response.WriteAsync(json);
            }
            catch (DomainException ex)
            {
                context.Response.StatusCode = 400;

                context.Response.Headers.Add("content-type", "application/json");

                string json = JsonSerializer.Serialize(new { ex.Message });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
