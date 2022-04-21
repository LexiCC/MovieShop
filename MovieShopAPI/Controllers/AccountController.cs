using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _accountService.ValidateUser(model.Email, model.Password);
            // JWT 
            // SPA (Angualar) , iOS , Android
            // Json Web Token
            // If user/pass valid then we created a Cookie, which has claims information, 
            // ASP.NET can decrypt thhat cooke to get back oringnal info
            // Token, (JWT) => 

            // get the claims

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim("language", "english"),
                 new Claim( JwtRegisteredClaimNames.GivenName , user.FirstName),
                 new Claim( JwtRegisteredClaimNames.FamilyName , user.LastName),
                 new Claim( JwtRegisteredClaimNames.Email , user.Email),
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // secret key 
            // connection strings, secret keys
            // Azure KeyVault => Storing any secret information, connection string, secret keys

            var privateKey = _configuration["privateKey"];
            var expirationTime = _configuration.GetValue<int>("expirationHours");
            var issuer = _configuration["issuer"];
            var audience = _configuration["audience"];

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtExpirationTime = DateTime.UtcNow.AddHours(expirationTime);

            // JwtSecurityHandler
            var handler = new JwtSecurityTokenHandler();

            // describe the object to create all the information needed for token
            var tokenDescription = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = identityClaims,
                Issuer = issuer,
                Audience = audience,
                Expires = jwtExpirationTime
            };

            var jwtToken = handler.CreateToken(tokenDescription);
            return Ok(new { token = handler.WriteToken(jwtToken) });
            // {"token":"fnlkdsnfkldsnfkldsnfkldsnflkjdfdfnnlsdnmflsmnflksnm"}
            // 200 OK
            // if someone needs secure information, buy movie, create review, favorite a movie
            // asp.net Authorize
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register( RegisterModel model )
        {
            var user = await _accountService.RegisterUser(model);
            return Ok(user);
        }
    }
}
