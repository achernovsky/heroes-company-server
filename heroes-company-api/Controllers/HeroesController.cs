using heroes_company_api.Dtos;
using heroes_company_api.Models;
using heroes_company_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace heroes_company_api.Controllers
{
    [Route("heroes")]
    [ApiController]
    [Authorize(Roles = "Trainer")]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepo _repository;

        public HeroesController(IHeroesRepo reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet]
        public async Task<ActionResult> GetHeroes()
        {
            var heroes = await _repository.GetHeroes();
            return Ok(_repository.toDtoList(heroes));
        }

        [HttpGet("trainer/{trainerId}")]
        public async Task<ActionResult> GetTrainerHeroes(Guid trainerId)
        {
            var myHeroes = await _repository.GetTrainerHeroes(trainerId);
            return Ok(_repository.toDtoList(myHeroes));
        }

        [HttpPost]
        public async Task<ActionResult> CreateHero(CreateHeroDto heroDto)
        {
            if (ModelState.IsValid)
            {
                var heroModel = _repository.toHero(heroDto);
                var created = await _repository.CreateHero(heroModel);
                if (created)
                    return StatusCode(201);
                else
                    throw new Exception("Server error");
            }
            else
                return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> TrainHero(Guid id)
        {
            decimal result = await _repository.TrainHero(id);
            if (result == -2)
                return BadRequest();
            else
                return Ok(result);
        }
    }
}
