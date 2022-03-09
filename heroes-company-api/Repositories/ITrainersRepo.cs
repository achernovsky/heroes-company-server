using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using heroes_company_api.Models;

namespace heroes_company_api.Repositories
{
    public interface ITrainersRepo
    {
        Task RegisterTrainer(RegisterTrainerModel model);
        Task<JwtSecurityToken> Login(LoginModel model);
        String WriteToken(JwtSecurityToken token);
    }
}
