using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubePlay.Models.Base
{
    public class BaseServiceResult<T>
    {
        public bool IsSuccess { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public T Data { get; set; }
    }
}
