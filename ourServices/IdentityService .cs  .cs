using ourModels.Interfaces;
using ourModels.models;
using ourProject.ourModels.Interfaces;
using ourProject.ourModels.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ourServices
{
    public class IdentityService : Iidentity
    {
        private IWorkerService _workerService;
        public IdentityService(IWorkerService workerService)
        {
            _workerService = workerService;

        }
        private static SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
        private static string issuer = "https://my-pizza.com";
        //without statid-with DI
        public SecurityToken GetToken(List<Claim> claims) =>
         new JwtSecurityToken(
             issuer,
             issuer,
             claims,
             expires: DateTime.Now.AddDays(30.0),
             signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
         );

        public static TokenValidationParameters GetTokenValidationParameters() =>
            new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };

        public SecurityToken Login(User user)
        {
            var workers = _workerService.GetWorkers();
            var existWorker = workers.FirstOrDefault(Worker => ((Worker.Name.Equals(user.Name))&&(Worker.Password).Equals(user.Password)));
            if (existWorker == null)
                return null;

            List<Claim> Claims = new List<Claim>
            {
                //new Claim("role", existWorker.Role.ToString()),
                new Claim("UserType" ,existWorker.Role.ToString()),
                new Claim("userId", existWorker.Id.ToString())
            };
            //if (user.TaskManager)
            //    claims.Add(new Claim("UserType", "Agent"));

            var token = this.GetToken(Claims);
            return token;
        }






        //    // return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
    }


}
