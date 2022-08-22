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
    /// Account Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IService<AccountResponse, AccountRequest> _accountService;

        /// <summary>
        /// Account Controller Constructor.
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="accountService">Account Service</param>
        public AccountController(ILogger<AccountController> logger, IService<AccountResponse, AccountRequest> accountService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        // GET
        // api/account/list
        /// <summary>
        /// List all accounts.
        /// </summary>
        /// <returns>Return a list of accounts.</returns>
        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked.", nameof(ListAsync));

            try
            {
                return Ok(await _accountService.ListAsync());
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(ListAsync), ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST
        // api/account/create
        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="request">Account View Model</param>
        /// <returns>Return the created account.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] AccountRequest request)
        {
            _logger?.LogDebug("'{0}' has been invoked.", nameof(CreateAsync));

            try
            {
                var account = await _accountService.CreateAsync(request);

                return account.Success
                    ? Ok(account)
                    : BadRequest(account.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(CreateAsync), ex);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
