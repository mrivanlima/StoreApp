using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Wrapper
{
    public class Result<T>
    {
        public T? Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public string? ErrorMessage { get; private set; }

        // Success result
        public static Result<T> Success(T data)
        {
            return new Result<T> { Data = data, IsSuccess = true };
        }

        // Failure result
        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
        }

    }
}
