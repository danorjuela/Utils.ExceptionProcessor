using Danorjuela.Utils.ResponseProcessor.DTOs;
using Danorjuela.Utils.ResponseProcessor.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Security.Claims;

namespace Danorjuela.Utils.ResponseProcessor.Services
{
    public class ResponseService : IResponseService
    {

        public IActionResult ProcessException(Exception ex)
        {
            var g = Guid.NewGuid().ToString();

            switch (ex)
            {
                case INotFoundException:
                    return GenerateReponse(ex, StatusCodes.Status404NotFound, g);
                case InvalidOperationException:
                    return GenerateReponse(ex, StatusCodes.Status400BadRequest, g);
                case INoDataException:
                    return GenerateReponse(ex, StatusCodes.Status204NoContent, g);
                case INotAutorizationException:
                    return GenerateReponse(ex, StatusCodes.Status401Unauthorized, g);
                case IConflicException:
                    return GenerateReponse(ex, StatusCodes.Status409Conflict, g);
                case IBusinessException:
                    return GenerateReponse(ex, StatusCodes.Status418ImATeapot, g);
                default:
                    return GenerateReponse(ex, StatusCodes.Status500InternalServerError, g);
            }
        }

        private ObjectResult GenerateReponse(Exception ex, int statusCode, string guid = "")
        {
            var tipoEx = ex.GetType();
            var isGeneric = tipoEx.IsGenericType;
            if (isGeneric)
            {
                var typeGeneric = tipoEx.GetGenericArguments().First();
                var typeDataProperty = tipoEx.GetProperty("ObjectData");
                var typeDataPropertyValue = typeDataProperty.GetValue(ex);
                var typeResponseDTO = typeof(ResponseDTO<>).MakeGenericType(typeGeneric);
                var reponse = Activator.CreateInstance(typeResponseDTO);
                PropertyInfo MessageProperty = reponse.GetType().GetProperty("Message");
                MessageProperty.SetValue(reponse, ex.Message);
                PropertyInfo DataProperty = reponse.GetType().GetProperty("Data");
                DataProperty.SetValue(reponse, typeDataPropertyValue);
                PropertyInfo guidProperty = reponse.GetType().GetProperty("Guid");
                guidProperty.SetValue(reponse, guid);
                return new ObjectResult(reponse)
                {
                    StatusCode = statusCode
                };
            }
            else
            {
                return new ObjectResult(new ResponseDTO() { Message = ex.Message, IsSuccess = false, Guid = guid })
                {
                    StatusCode = statusCode

                };
            }
        }

        public IActionResult ProcessException(Exception ex, int? code = null)
        {
            if (code != null)
            {
                return GenerateReponse(ex, code.Value);
            }
            else
            {
                return ProcessException(ex);
            }
        }

        public IActionResult ProcessResponse<T>(T data, int? code = 200)
        {
            var guid = Guid.NewGuid().ToString();
            return new ObjectResult(new ResponseDTO<T>() { Message = "", Data = data, Guid = guid })
            {
                StatusCode = code
            };
        }

    }
}
