using FantasyFootball.Common.Results;
using System;

namespace FantasyFootball.Common.Exceptions
{
    public class CustomException : Exception
    {
        protected ExceptionTypes ExceptionType { get; set; }
        protected object ResultData { get; set; }
        
        public CustomException()
        {
        }

        public CustomResult Get()
        {
            return new CustomResult(ExceptionType, ResultData);
        }
    }
}
