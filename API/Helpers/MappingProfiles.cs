using System.Security.Cryptography.X509Certificates;
using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bank,BankToReturnDto>()
            .ForMember(d=>d.Picture, o => o.MapFrom<BankUrlResolver>()).ReverseMap();
        }
    }
}