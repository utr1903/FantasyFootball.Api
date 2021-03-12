namespace FantasyFootball.Common.Exceptions
{
    public class NotValidException : CustomException
    {
        public NotValidException()
        {
        }
    }

    public class RequestNotValid : NotValidException
    {
        public RequestNotValid(object resultData)
        {
            ExceptionType = ExceptionTypes.NOT_VALID;
            ResultData = resultData;
        }
    }
}
