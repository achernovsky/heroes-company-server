using heroes_company_api.Dtos;
using heroes_company_api.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroes_company_api.Repositories
{
    public interface IHeroesRepo
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<Hero>> GetHeroes();
        Task<IEnumerable<Hero>> GetTrainerHeroes(Guid trainerId);
        Task<bool> CreateHero(Hero hero);
        Task<decimal> TrainHero(Guid id);
        HeroDto toDto(Hero hero);
        IEnumerable<HeroDto> toDtoList(IEnumerable<Hero> heroes);
        Hero toHero(CreateHeroDto hero);
    }
}
