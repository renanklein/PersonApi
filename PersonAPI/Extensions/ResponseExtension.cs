using Microsoft.AspNetCore.Mvc;
using System;

namespace PersonAPI.Extensions
{
    public static class ResponseExtension
    {
        public static ObjectResult AsObjectResult<TResponse>(this TResponse response) where TResponse : class
        {
            throw new NotImplementedException();
        }
    }
}
