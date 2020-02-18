using System;
using System.Collections.Generic;
using System.Text;

namespace Test.DataAccess.Dto
{
    public class ResponseDto<T>
    {
        public int value { get; set; }
        public string msg { get; set; }
        public T result { get; set; }
    }
}
