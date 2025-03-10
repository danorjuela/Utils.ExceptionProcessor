using Danorjuela.Utils.ResponseProcessor.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Security.Claims;

namespace Danorjuela.Utils.ResponseProcessor.DTO
{
    public class ResponseDTO<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public string? Guid { get; set; }
    }


    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? Guid { get; set; }
    }
}
