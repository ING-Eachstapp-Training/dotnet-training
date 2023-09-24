using System;
using chapter_4.BL;
using chapter_4.DTO;
using chapter_4.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace chapter_4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UsersBL _usersBL;

        public AuthenticationController(ILogger<AuthenticationController> logger, UsersBL usersBL)
        {
            _logger = logger;
            _usersBL = usersBL;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<TaskDTO>> LoginAsync(string email)
        {
            _logger.LogInformation("[AuthenticationController][Login()] entered controller");
            var userId = await _usersBL.GetUserWithEmailAsync(email);
            if (userId == null)
            {
                throw new WrongCredentialsException();
            }
            return new OkObjectResult(userId);
        }

    }
}

