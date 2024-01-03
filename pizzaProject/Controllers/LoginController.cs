using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ourModels.Interfaces;
using ourModels.models;



namespace pizzaProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private Iidentity _identityService;
        public LoginController(Iidentity identityService)
        {
            _identityService = identityService;
        }
        [HttpPost]
        [Route("[action]")]

        public ActionResult<String> Login([FromBody] User user)
        {
            var token = _identityService.Login(user);
            if(token == null)
                throw new UnauthorizedAccessException("Unauthorized");
            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
           
        }
       
    }
}