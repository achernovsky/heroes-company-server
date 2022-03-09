using heroes_company_api.Models;
using heroes_company_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace heroes_company_api.Controllers
{
    [Route("users")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private ITrainersRepo _repository;

        public TrainersController(ITrainersRepo repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterTrainer([FromBody] RegisterTrainerModel model)
        {
            await _repository.RegisterTrainer(model);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _repository.Login(model);
            if (token != null)
                return Ok(new
                {
                    token = _repository.WriteToken(token),
                    username = token.Claims.ToArray()[0].Value,
                    userid = token.Claims.ToArray()[1].Value,
                    expires = token.ValidTo
                });
            else
                return Unauthorized();
        }
    }
}
