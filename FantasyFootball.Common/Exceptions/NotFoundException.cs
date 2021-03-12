namespace FantasyFootball.Common.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException()
        {
        }
    }

    public class UserNotFound : NotFoundException
    {
        public UserNotFound()
        {
            ExceptionType = ExceptionTypes.NOT_FOUND;
            ResultData = "User not found!";
        }
    }
}
