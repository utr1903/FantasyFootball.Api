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

    public class UserTeamNotFound : NotFoundException
    {
        public UserTeamNotFound()
        {
            ExceptionType = ExceptionTypes.NOT_FOUND;
            ResultData = "User team not found!";
        }
    }

    public class PlayerHistoryNotFound : NotFoundException
    {
        public PlayerHistoryNotFound()
        {
            ExceptionType = ExceptionTypes.NOT_FOUND;
            ResultData = "Player history not found!";
        }
    }
}
