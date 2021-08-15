using API.Dto;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class BankUrlResolver : IValueResolver<Bank, BankToReturnDto, string>
    {
        private readonly IConfiguration e_config;
        public BankUrlResolver(IConfiguration config)
        {
            e_config = config;

        }
        public string Resolve(Bank source, BankToReturnDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.ImageUrl))
           {
               return e_config["ApiUrl"] + source.ImageUrl;
           }
           return null;
        }
    }
}