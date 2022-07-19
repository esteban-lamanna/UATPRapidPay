using Microsoft.AspNetCore.Http;
using RapidPay.EnterpriseBusinessRules.Exceptions;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drivers.RapidPay.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidCardException e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { message = e?.Message });
                response.StatusCode = 400;
                await response.WriteAsync(result);
            }
            catch (CardNumberInUseException e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { message = e?.Message });
                response.StatusCode = 400;
                await response.WriteAsync(result);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { message = e?.Message });
                response.StatusCode = 500;
                await response.WriteAsync(result);
            }
        }
    }
}