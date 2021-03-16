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

    public class PlayerPositionNotValid : NotValidException
    {
        public PlayerPositionNotValid()
        {
            ExceptionType = ExceptionTypes.NOT_VALID;
            ResultData = "Player cannot play on this position!";
        }
    }
}
