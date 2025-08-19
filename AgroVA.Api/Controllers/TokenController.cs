using AgroVA.Api.helpers;
using AgroVA.Api.Models;
using AgroVA.Domain.Account;
using AgroVA.Domain.Entities;
using AgroVA.Domain.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgroVA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticateService, IConfiguration configuration)
        {
            _authenticateService = authenticateService;
            _configuration = configuration;
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<UserToken>> RefreshToken([FromBody] UserToken userToken)
        {
            if (string.IsNullOrWhiteSpace(userToken.Token)) return BadRequest();

            var isValidTokenResult = await _authenticateService.ValidateTokenAsync(userToken.Token);

            if (!isValidTokenResult.isValid) return Unauthorized();

            var user = await _authenticateService.GetUser(isValidTokenResult.email ?? "");

            if (user is null) return Unauthorized();

            Response.Cookies.Append(
                    "RefreshToken",
                    _authenticateService.GenerateRefreshToken(user),
                    new CookieOptions()
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });

            return Ok(new UserToken()
            {
                Token = await _authenticateService.GenerateToken(user)
            });
        }


        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (model.Email == null || model.Password == null) return BadRequest();

            var user = await _authenticateService.Authenticate(model.Email, model.Password);

            if (user is null)
            {
                ModelState.AddModelError("Error", UserMessage.InvalidLogin);
                return ValidationErrorResponseBuilder.BadRequest(HttpContext, ModelState);
            }
            else
            {
                Response.Cookies.Append(
                    "RefreshToken",
                    _authenticateService.GenerateRefreshToken(user),
                    new CookieOptions()
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });

                return new UserToken()
                {
                    Token = await _authenticateService.GenerateToken(user)
                };
            }
        }

        [HttpGet("me")]
        [Authorize(Roles = "Admin")] // ← só entra se estiver autenticado
        public IActionResult GetUserInfo()
        {
            var user = HttpContext.User;

            if (user.Identity?.IsAuthenticated != true)
            {
                return Unauthorized("Usuário não autenticado.");
            }

            var claims = user.Claims.Select(c => new { c.Type, c.Value });

            return Ok(new
            {
                user.Identity.Name,
                Claims = claims
            });
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> Register([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (model.Email == null || model.Password == null || model.Name == null) return BadRequest();

            var result = await _authenticateService.Register(model.Email, model.Name, model.Password);

            if (result)
            {
                return Ok($"Usuário '{model.Email}' foi cridao com sucesso.");
            }
            else
            {
                ModelState.AddModelError("Error", "Não foi possivel cadastrar o email.");
                return ValidationErrorResponseBuilder.BadRequest(HttpContext, ModelState);
            }
        }
    }
}
