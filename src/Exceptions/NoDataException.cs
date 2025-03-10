using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danorjuela.Utils.ResponseProcessor.Interface;

namespace Danorjuela.Utils.ResponseProcessor.Exceptions
{
    /// <summary>
    /// Se utiliza cuando el recurso no esta disponible
    /// </summary>
    public class NoDataException<T> : Exception , INoDataException
    {
        public T ObjectData { get; set; }

        public NoDataException(string message, T data)
            : base(message)
        {
            ObjectData = data;
        }
    }


    public class NoDataException : Exception, INoDataException
    {
        public NoDataException(string message)
            : base(message)
        {
        }
    }
}
