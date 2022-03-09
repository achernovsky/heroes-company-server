using heroes_company_api.Dtos;
using heroes_company_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;

namespace heroes_company_api.Repositories
{
    public class HeroesRepo : IHeroesRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private string userId;

        public HeroesRepo(ApplicationDbContext context, IHttpContextAccessor httpContext, IMapper mapper)
        {
            _context = context;
            _httpContext = httpContext;
            _mapper = mapper;
            userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<bool> SaveChanges()
        {
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            var heroes = await _context.Heroes.ToListAsync();
            return heroes;
        }

        public async Task<IEnumerable<Hero>> GetTrainerHeroes(Guid trainerId)
        {
            if (trainerId.ToString() != userId)
                throw new Exception("Access denied");
            var heroes = await _context.Heroes.ToListAsync();
            var myHeroes = heroes.FindAll(h => h.TrainerId == userId);
            return myHeroes;
        }

        public async Task<bool> CreateHero(Hero hero)
        {
            if (hero == null)
                return false;

            var newHero = new Hero(userId , hero.Name, hero.Ability, hero.SuitColors, hero.StartingPower);
            await _context.Heroes.AddAsync(newHero);
            var created = await SaveChanges();
            return created;
        }

        public async Task<decimal> TrainHero(Guid id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null || hero.TrainerId != userId)
                return -2;

            decimal powerLevelIncreased = hero.Train();

            if (powerLevelIncreased == -1 || await SaveChanges())
                return powerLevelIncreased;
            else
                throw new Exception("Server Error");
        }

        public HeroDto toDto(Hero hero)
        {
            return _mapper.Map<HeroDto>(hero);
        }

        public Hero toHero(CreateHeroDto hero)
        {
            return _mapper.Map<Hero>(hero);
        }

        public IEnumerable<HeroDto> toDtoList(IEnumerable<Hero> heroes)
        {
            List<HeroDto> heroesDto = new List<HeroDto>();
            foreach (Hero h in heroes)
            {
                heroesDto.Add(toDto(h));
            }
            return heroesDto;
        }
    }
}
