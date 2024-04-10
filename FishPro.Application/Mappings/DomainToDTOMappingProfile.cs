using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FishPro.Application.Services.DTO;
using FishPro.Core.Entities;

namespace FishPro.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        { 
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Tournament, TournamentDTO>().ReverseMap();
            CreateMap<Stage, StageDTO>().ReverseMap();
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<Result, ResultDTO>().ReverseMap();
        }
    }
}
