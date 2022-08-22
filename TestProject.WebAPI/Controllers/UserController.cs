using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestProject.WebAPI.Services.Interface;
using TestProject.WebAPI.ViewModels;

namespace TestProject.WebAPI.Controllers
{
    /// <summary>
    /// User Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// User Controller Constructor.
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="userService">User Service</param>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET
        // api/user/list
        /// <summary>
        /// List all users.
        /// </summary>
        /// <returns>Return a list of users.</returns>
        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked.", nameof(ListAsync));

            try
            {
                return Ok(await _userService.ListAsync());
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(ListAsync), ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST
        // api/user/create
        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="request">User request</param>
        /// <returns>Return the created user.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest request)
        {
            _logger?.LogDebug("'{0}' has been invoked.", nameof(CreateAsync));

            try
            {
                var user = await _userService.CreateAsync(request);

                return user.Success
                    ? Ok(user)
                    : BadRequest(user.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(CreateAsync), ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET
        // api/user/get/{emailAddress}
        /// <summary>
        /// Get a user by email address.
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <returns>Return a user.</returns>
        [HttpGet("{emailAddress}")]
        public async Task<IActionResult> GetAsync(string emailAddress)
        {
            _logger?.LogDebug("'{0}' has been invoked.", nameof(GetAsync));

            try
            {
                var user = await _userService.GetAsync(emailAddress);

                return user.Success
                    ? Ok(user)
                    : BadRequest(user.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetAsync), ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}