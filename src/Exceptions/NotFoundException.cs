using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danorjuela.Utils.ResponseProcessor.Interface;


namespace Danorjuela.Utils.ResponseProcessor.Exceptions {

    /// <summary>
    /// Se utiliza en caso de no encontrar un recurso 
    /// </summary>
    public class NotFoundException<T> : Exception, INotFoundException
    {
        public T ObjectData { get; set; }

        public NotFoundException(string message, T data)
            : base(message)
        {
            ObjectData = data;
        }
    }


    public class NotFoundException : Exception, INotFoundException
    {
        public NotFoundException(string message)
            : base(message)
        { }
    }


}
