using EJumping.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.Application.Common
{
    public static class ResponseHelper
    {
        public static ApiResponseBase ToResponse(this IResponseContext context)
        {
            ApiResponseBase rp = new ApiResponseBase
            {
                Errors = context.IsError ? context.Errors.Select(m => m.Value).ToList<object>() : null
            };
            return rp;
        }

        public static ApiResponse<T> ToResponse<T>(this IResponseContext context, T data)
        {
            ApiResponse<T> rp = new ApiResponse<T>(data)
            {
                Errors = context.IsError ? context.Errors.Select(m => m.Value).ToList<object>() : null
            };

            return rp;
        }
    }
}
