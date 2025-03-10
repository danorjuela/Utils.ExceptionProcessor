using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danorjuela.Utils.ResponseProcessor.Interface;

namespace Danorjuela.Utils.ResponseProcessor.Exceptions
{
    public class BusinessException<T> : Exception , IBusinessException
    {
        public T ObjectData { get; set; }

        public BusinessException(string message, T data)
            : base(message)
        {
            ObjectData = data;
        }
    }


    public class BusinessException : Exception , IBusinessException
    {
        public BusinessException(string message)
            : base(message)
        { }
    }
}
