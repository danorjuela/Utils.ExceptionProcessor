using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danorjuela.Utils.ResponseProcessor.Interface;


namespace Danorjuela.Utils.ResponseProcessor.Exceptions
{
    /// <summary>
    /// Cuando no tienes acceso al recurso (no tienes permiso)
    /// </summary>
    public class ForbiddenException<T> : Exception , IForbiddenException
    {
        public T ObjectData { get; set; }

        public ForbiddenException(string message, T data)
          : base(message)
        {
            ObjectData = data;
        }
    }

    public class ForbiddenException : Exception, IForbiddenException
    {
        public ForbiddenException(string message)
          : base(message)
        {
        }
    }


}
