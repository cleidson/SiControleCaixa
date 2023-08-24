using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.DTO.Account;
using SiControleCaixa.ApplicationCore.DTO.Transacao;
using SiControleCaixa.Infrastructure.Data.Models;

namespace SiControleCaixa.Application.NET7.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService; 
        private readonly JwtConfiguration _config;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, IOptions<JwtConfiguration> config)
        {
            _logger = logger;
            _accountService = accountService;
            _config = config.Value;
        }


        [HttpPost("register-account")]
        public async Task<ActionResult> Register(AccountDto registerAccount)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(t=>t.Errors));

            if (await _accountService.RegisterAccount(registerAccount))
                return Ok();
            else
                return BadRequest();
        }


        [HttpPost("Login")]
        public async Task<string> Login(AccountDto credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("Login credentials");
            }
            if (await _accountService.Login(credentials))
            {
                return await _accountService.GenerateTokenString(credentials.UserName, _config);
            }
            return null;
        }

    }
}
