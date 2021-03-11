using FantasyFootball.Service.PrimitiveServices.UsersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FantasyFootball.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServiceP _usersService;
        public UsersController(IUsersServiceP usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("GetUser")]
        //[Authorize(Policy = Policies.User)]
        [Authorize]
        public ActionResult GetUser([FromBody] Guid userId)
        {
            var user = _usersService.Get(userId);
            return Ok(user);
        }
    }
}
