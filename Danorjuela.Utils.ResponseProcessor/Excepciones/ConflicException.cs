using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danorjuela.Utils.ResponseProcessor.Interface;

namespace Danorjuela.Utils.ResponseProcessor.Exceptions { 
    /// <summary>
    /// Se utiliza cuando no se puede modificar un recurso
    /// o el recurso no esta disponible
    /// </summary>
    public class ConflicException<T> : Exception , IConflicException
    {
        public T ObjectData { get; set; }

        public ConflicException(string message, T data)
            : base(message)
        {
            ObjectData = data;
        }
    }


    public class ConflicException : Exception , IConflicException
    {
        public ConflicException(string message)
            : base(message)
        { }
    }
}
