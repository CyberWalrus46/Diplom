using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Some_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new {Name = "Masha"},
                new {Name = "Misha"}
            };
            return Ok(users);
        }
    }
}
