using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca.Entities;
using Biblioteca.Commons;
using Biblioteca.Services;
using Biblioteca.Interfaces;
using ILogger = Biblioteca.Commons.Logging.ILogger;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService, ILogger logger) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly ILogger _Logger = logger;

        [HttpPost]
        public IActionResult Create([FromForm] string name, [FromForm] string email)
        {
            try
            {
                _Logger.Info($"[UserController] Attempting to create user: {name}");
                var result = _userService.Create(name, email);
                if (!result)
                {
                    _Logger.Error($"[UserController] Failed to create user: {name}");
                    return BadRequest("Failed to create user");
                }
            }
            catch (Exception ex)
            {
                _Logger.Error($"[UserController] Error creating user: {name}", ex);
                return BadRequest($"Error creating user: {ex.Message}");
            }
            _Logger.Info($"[UserController] Successfully created user: {name}");
            return Ok("User created successfully");

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                _Logger.Info("[UserController] Attempting to retrieve all users");
                var users = _userService.GetAll();
                _Logger.Info($"[UserController] Successfully retrieved {users.Count} users");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _Logger.Error("[UserController] Error retrieving users", ex);
                return BadRequest($"Error retrieving users: {ex.Message}");
            }
        
        }
}
}