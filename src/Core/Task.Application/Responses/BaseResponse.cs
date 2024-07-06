using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
    }
    public class BaseResponse<T> :BaseResponse
    {
        public T Result { get; set; }
    }
}
