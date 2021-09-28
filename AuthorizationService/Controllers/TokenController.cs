using AuthorizationService.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IAuthService authService;
        public readonly log4net.ILog logs;

        public TokenController(IAuthService authService)
        {
            logs = log4net.LogManager.GetLogger(typeof(TokenController));
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult GenerateJSONWebToken()
        {
            logs.Info(" Http GET Request From: " + nameof(TokenController));
            string Token = authService.GetJsonWebToken();
            if (Token == null)
            {
                return BadRequest(Token);
            }
            else
            {
                return Ok(Token);
            }
            
        }
    }
}
