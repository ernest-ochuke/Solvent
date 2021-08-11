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
        public async Task<ActionResult<List<BankToReturnDto>>> GetBanks()
        {
            var spec = new BanksWithCardProductSpecification();
            var banks = await e_bankRepo.ListAsync(spec);
              
            return Ok(e_mapper.Map<List<BankToReturnDto>>(banks));
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