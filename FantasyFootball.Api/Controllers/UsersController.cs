using FantasyFootball.Service.PrimitiveServices.UsersService;
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

        [HttpGet]
        public ActionResult Get()
        {
            var userId = Guid.Parse("B68E014E-E8A5-4D37-B78E-1AE34AE13869");
            var user = _usersService.Get(userId);
            return Ok(user);
        }
    }
}
