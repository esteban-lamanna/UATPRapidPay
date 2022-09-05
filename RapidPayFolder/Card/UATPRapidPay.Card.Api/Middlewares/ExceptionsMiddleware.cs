using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Api.Middlewares
{
    public class ExceptionsMiddleware : IMiddleware
    {
        private readonly IExceptionToResponseMapper _exceptionToResponseMapper;

        public ExceptionsMiddleware(IExceptionToResponseMapper exceptionToResponseMapper)
        {
            _exceptionToResponseMapper = exceptionToResponseMapper;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var exceptionResponse = _exceptionToResponseMapper.Map(ex);

                context.Response.StatusCode = (int)(exceptionResponse?.StatusCode ?? HttpStatusCode.BadRequest);

                var response = exceptionResponse?.Response;

                if (response is null)
                {
                    await context.Response.WriteAsync(string.Empty);
                    return;
                }

                context.Response.ContentType = "application/json";

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}