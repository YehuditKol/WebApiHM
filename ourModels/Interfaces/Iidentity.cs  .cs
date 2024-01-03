
using Microsoft.IdentityModel.Tokens;
using ourModels.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ourModels.Interfaces
{
    public interface Iidentity 
    {
        public  SecurityToken GetToken(List<Claim> claims);
        //public TokenValidationParameters GetTokenValidationParameters();
        public SecurityToken Login(User user);

    }
}