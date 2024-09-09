using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Utility
{
    public class APIResponse
    {
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool isSuccess { get; set; }
    }
}
