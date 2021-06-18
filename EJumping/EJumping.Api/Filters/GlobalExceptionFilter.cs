using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using EJumping.Core.Enums;
using System;
using System.Net;
using System.Threading;
using EJumping.Core.Exceptions;

namespace EJumping.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private static ILogger _logger;
        private static string _showLogLevel;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IConfiguration configuration)
        {
            _logger = logger;
            _showLogLevel = configuration["Tracing:ShowLogLevel"];
        }

        private string GetErrorMessage(Exception ex)
        {
            if (ex is ValidationException)
            {
                return ex.Message;
            }

            var showLogLevel = Enum.Parse<ShowLogLevel>(_showLogLevel);
            string output;
            switch (showLogLevel)
            {
                case ShowLogLevel.Production:
                    output = "An internal exception occurred. We'll take care of it.";
                    break;

                case ShowLogLevel.Stacktrace:
                    output = ex.StackTrace;
                    break;

                default:
                    output = ex.Message;
                    break;
            }

            return output;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.Result = new BadRequestObjectResult(new { Message = GetErrorMessage(context.Exception) });
            }
            else
            {
                _logger.LogError(context.Exception, "Heyyy-[{0}-{1}]", DateTime.UtcNow.Ticks, Thread.CurrentThread.ManagedThreadId);

                context.Result = new ObjectResult(new { Message = GetErrorMessage(context.Exception) })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

            }
        }
    }
}
