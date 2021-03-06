﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace CameraBazaar.Web.Infrastructures.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            using (var writer = new StreamWriter("logs.txt", true))
            {
                var dateTime = DateTime.UtcNow;
                var ipAdress = context.HttpContext.Connection.RemoteIpAddress;
                var userName = context.HttpContext.User?.Identity?.Name ?? "Anonymous";
                var controller = context.Controller.GetType().Name;
                var action = context.ActionDescriptor.DisplayName;

                var logMessage = $"{dateTime} - {ipAdress} - {userName} - {controller}.{action}";

                if (context.Exception != null)
                {
                    var exceptionType = context.Exception.GetType().Name;
                    var exceptionMessage = context.Exception.Message;

                    logMessage = $"[!] - {logMessage} {exceptionType} - {exceptionMessage}";
                }

                writer.WriteLine(logMessage);
            }
        }
    }
}
