namespace FantasyFootball.Common.Exceptions
{
    public class NotAuthorizedException : CustomException
    {
        public NotAuthorizedException()
        {
        }
    }

    public class UserNotAuthorized : NotAuthorizedException
    {
        public UserNotAuthorized()
        {
            ExceptionType = ExceptionTypes.NOT_AUTHORIZED;
            ResultData = "User not authorized!";
        }
    }
}
