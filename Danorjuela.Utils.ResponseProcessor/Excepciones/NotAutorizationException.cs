using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danorjuela.Utils.ResponseProcessor.Interface;


namespace Danorjuela.Utils.ResponseProcessor.Exceptions
{
    /// <summary>
    /// Cuando no estas autenticado 
    /// </summary>
    public class NotAutorizationException<T> : Exception, INotAutorizationException
    {
        public T ObjectData { get; set; }

        public NotAutorizationException(string message, T data)
            : base(message)
        {
            ObjectData = data;
        }
    }


    public class NotAutorizationException : Exception, INotAutorizationException
    {
        public NotAutorizationException(string message)
            : base(message)
        { }
    }
}
