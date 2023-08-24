using Microsoft.AspNetCore.Identity;
using SiControleCaixa.ApplicationCore.DTO.Account;
using SiControleCaixa.ApplicationCore.DTO.Transacao;
using SiControleCaixa.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.BusinessServices.Interfaces
{
    public interface IAccountService
    {

        Task<bool> RegisterAccount(AccountDto user);
        Task<bool> AddUserClaim(string user, Claim claim);
        Task GenerateCookieAuthentication(string username);
        Task<string> GenerateTokenString(string user, JwtConfiguration jwtConfig);
        Task<bool> Login(AccountDto credentials);
        Task Logout();
        
    }
}
