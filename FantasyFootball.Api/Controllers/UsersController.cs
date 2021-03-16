using FantasyFootball.Common.Exceptions;
using FantasyFootball.Service.AdvancedServices.UserServiceA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FantasyFootball.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Advanced Services
        private readonly IUserServiceA _usersServiceA;

        public UsersController(IUserServiceA usersServiceA)
        {
            _usersServiceA = usersServiceA;
        }

        [HttpPost]
        [Route("GetUserSettings")]
        //[Authorize(Policy = Policies.User)]
        [Authorize]
        public ActionResult GetUserSettings([FromBody] Guid userId)
        {
            try
            {
                var user = _usersServiceA.GetUserSettings(userId);
                return Ok(user);
            }
            catch (CustomException e)
            {
                return Ok(e.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
