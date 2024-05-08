using CoreLayer.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Results.Concrete
{
    public class Result : IResult
    {
            public Result(bool IsSucces)
            {
                IsSuccess = IsSucces;
            }

            public Result(string message, bool IsSuccess) : this(IsSuccess)
            {
                Message = message;
            }

            public string Message { get; }

            public bool IsSuccess { get; }
    }
}
