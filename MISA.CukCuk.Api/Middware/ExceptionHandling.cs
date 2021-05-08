using Microsoft.AspNetCore.Http;
using MISA.Core.Enum;
using MISA.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Middware
{
    /// <summary>
    /// Middleware phục vụ bắt Exception
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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
        /// <summary>
        /// Sử lý Exception
        /// </summary>
        /// <param name="context">Bối cảnh hiện tại</param>
        /// <param name="exception"></param>
        /// <returns>Message cho các exception</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //HttpStatusCode status;
            //string message;
            var response = new
            {
                devMsg = exception.Message,
                userMsg = MISAConstant.User_Msg_Error,
                MISACode = "002",
                Data = exception.Data
            };

            // throw new BaseException
            if (exception is BaseException)
            {
                response = new
                {
                    devMsg = exception.Message,
                    userMsg = MISAConstant.User_Msg_Error,
                    MISACode = "001",
                    Data = exception.Data
                };
                context.Response.StatusCode = 400;
            }
            else
            {
                response = new
                {
                    devMsg = exception.Message,
                    userMsg = MISAConstant.User_Msg_Error,
                    MISACode = "002",
                    Data = exception.Data
                };
                context.Response.StatusCode = 500;

            }

            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";


            return context.Response.WriteAsync(result);
        }
    }
}
