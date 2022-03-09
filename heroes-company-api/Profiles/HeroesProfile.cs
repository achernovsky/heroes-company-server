using AutoMapper;
using heroes_company_api.Dtos;
using heroes_company_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroes_company_api.Profiles
{
    public class HeroesProfile : Profile
    {
        public HeroesProfile()
        {
            CreateMap<Hero, HeroDto>();
            CreateMap<CreateHeroDto, Hero>();
        }
    }
}
