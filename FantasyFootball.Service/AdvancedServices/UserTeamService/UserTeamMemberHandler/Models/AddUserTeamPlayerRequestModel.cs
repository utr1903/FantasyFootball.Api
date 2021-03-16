using System;

namespace FantasyFootball.Service.AdvancedServices.UserTeamService.UserTeamMemberHandler.Models
{
    public class AddUserTeamPlayerRequestModel
    {
        public Guid PlayerHistoryId { get; set; }
        public Guid UserTeamId { get; set; }
        public int PositionId { get; set; }
    }
}
