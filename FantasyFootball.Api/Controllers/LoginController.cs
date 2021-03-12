using FantasyFootball.Common.Exceptions;
using FantasyFootball.Entity.Models;
using FantasyFootball.Service.AdvancedServices.UsersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace FantasyFootball.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // Advanced Services
        private readonly IUsersServiceA _userServiceA;

        // Config
        private readonly IConfiguration _configuration;

        public LoginController(

            // Advanced Services
            IUsersServiceA userServiceA,

            // Config
            IConfiguration configuration)
        {
            // Advanced Services
            _userServiceA = userServiceA;

            // Config
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User loginCreditentials)
        {
            if (!ModelState.IsValid)
                return ValidationProblem();

            try
            {
                var result = _userServiceA.AuthenticateUser(loginCreditentials);
                return Ok(result);
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
