using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; } = true;
        public T Result { get; set; }
    }
}
