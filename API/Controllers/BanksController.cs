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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
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
        public async Task<ActionResult<Bank>> GetBanks(int id)
        {
            var spec = new BanksWithCardProductSpecification(id);
            var banks = await e_bankRepo.GetEntityWithSpec(spec);

            return Ok(banks);
        }

    }
}