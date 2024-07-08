using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Task.Web.Models;


namespace Task.Web.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private async System.Threading.Tasks.Task HandleException(HttpContext httpContext, Exception exception)
        {

            HttpStatusCode statusCode=HttpStatusCode.InternalServerError;
            string errorMessage="internal servel error";
            switch (exception)
            {
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = exception.Message;
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorMessage= exception.Message;
                    break;
            }


            httpContext.Response.StatusCode = (int)statusCode;

            var result = new ViewResult
            {
                ViewName = "Error",               
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = new ErrorViewModel { StatusCode= (int)statusCode,Message=errorMessage }
                }
            };

            await result.ExecuteResultAsync(new ActionContext
            {
                HttpContext = httpContext,
                RouteData= httpContext.GetRouteData(),
                ActionDescriptor = new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor()
            });
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
