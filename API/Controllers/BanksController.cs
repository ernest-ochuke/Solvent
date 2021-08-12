using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dto;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
    public class BanksController : BaseApiController
    {

        private readonly IGenericRepository<Bank> e_bankRepo;
        private readonly IMapper e_mapper;

        public BanksController(IGenericRepository<Bank> bankRepo, IMapper mapper)
        {
            e_mapper = mapper;
            e_bankRepo = bankRepo;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<BankToReturnDto>>> GetBanks([FromQuery]BankSpecParams bankParams)
        {
            var spec = new BanksWithCardProductSpecification(bankParams);

            var countspec = new BanksWithFiltersForCountSpecification(bankParams);

            var totalItems = await e_bankRepo.CountAsync(countspec);

            var banks = await e_bankRepo.ListAsync(spec);

            var data = e_mapper.Map<IReadOnlyList<Bank>,IReadOnlyList<BankToReturnDto>>(banks);
              
            return Ok( new Pagination<BankToReturnDto>(bankParams.PageIndex,bankParams.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BankToReturnDto>> GetBanks(int id)
        {
            var spec = new BanksWithCardProductSpecification(id);
            var banks = await e_bankRepo.GetEntityWithSpec(spec);
            if(banks ==null) return NotFound(new ApiResponse(404));

            return Ok(e_mapper.Map<BankToReturnDto>(banks));
        }

    }
}