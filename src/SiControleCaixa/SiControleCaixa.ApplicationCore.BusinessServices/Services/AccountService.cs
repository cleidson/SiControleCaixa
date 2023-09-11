using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SiControleCaixa.ApplicationCore.BusinessServices.Helper;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.DTO.Account;
using SiControleCaixa.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.BusinessServices.Services
{
    public class AccountService : IAccountService
    {
        // SOLID: Dependency Injection (D)
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly IHttpContextAccessor _httpContext;

        // SOLID: Constructor Injection (D)
        public AccountService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContext = httpContext;
        }


        // SOLID: Single Responsibility Principle (S)
        // Login método lida apenas com o processo de autenticação do usuário
        public async Task<bool> Login(AccountDto credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user != null)
            {
                return await _userManager.CheckPasswordAsync(user, credentials.Password);
            }
            return false;
        }

        // SOLID: Single Responsibility Principle (S)
        // O método RegisterAccount lida apenas com o processo de registro do usuário
        public async Task<bool> RegisterAccount(AccountDto user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }

        // SOLID: Single Responsibility Principle (S)
        public async Task Logout()
        {
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        // SOLID: Single Responsibility Principle (S)
        public async Task GenerateCookieAuthentication(string username)
        {
            var claims = await GetClaims(username);

            ClaimsIdentity identity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal pricipal = new ClaimsPrincipal(identity);
            _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pricipal);
        }

        // SOLID: Single Responsibility Principle (S)
        public async Task<bool> AddUserClaim(string user, Claim claim)
        {
            var identityUser = await _userManager.FindByNameAsync(user);
            if (identityUser is null)
            {
                return false;
            }

            var result = await _userManager.AddClaimAsync(identityUser, claim);
            return result.Succeeded;
        }

        // SOLID: Single Responsibility Principle (S)
        private async Task<List<Claim>> GetClaims(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
            };

            claims.AddRange(GetClaimsSeperated(await _userManager.GetClaimsAsync(user)));
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

                var identityRole = await _roleManager.FindByNameAsync(role);
                claims.AddRange(GetClaimsSeperated(await _roleManager.GetClaimsAsync(identityRole)));
            }

            return claims;
        }

        // SOLID: Single Responsibility Principle (S)
        private List<Claim> GetClaimsSeperated(IList<Claim> claims)
        {
            var result = new List<Claim>();
            foreach (var claim in claims)
            {
                result.AddRange(claim.DeserializePermissions()
                    .Select(t => new Claim(claim.Type, t.ToString())));
            }
            return result;
        }

        // SOLID: Single Responsibility Principle (S)
        public async Task<string> GenerateTokenString(string user, JwtConfiguration jwtConfig)
        {
            var claims = await GetClaims(user);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Audience,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
