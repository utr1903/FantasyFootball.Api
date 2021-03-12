using FantasyFootball.Common.Exceptions;

namespace FantasyFootball.Common.Results
{
    public class CustomResult
    {
        public ResultTypes? ResultType { get; set; }
        public ExceptionTypes? ExceptionType { get; set; }
        public object ResultData { get; set; }

        public CustomResult(ResultTypes resultType, object resultData)
        {
            ResultType = resultType;
            ExceptionType = null;
            ResultData = resultData;
        }

        public CustomResult(ExceptionTypes exceptionType, object resultData)
        {
            ResultType = null;
            ExceptionType = exceptionType;
            ResultData = resultData;
        }
    }
}
