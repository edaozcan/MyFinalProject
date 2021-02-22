using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için
   public interface IResult
    {
        bool Success { get; }//get sadece okunabilir
        string Message { get; }

    }
}
