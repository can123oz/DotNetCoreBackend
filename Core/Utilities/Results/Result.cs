using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Constructor overloading
        public Result(bool success)
        {
            Success = success;
        }

        public Result(string message, bool success) : this(success)
        {
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; }

    }
}
