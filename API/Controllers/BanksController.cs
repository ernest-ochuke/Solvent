using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
       
        private readonly IBankRepository e_repo;
        public BanksController(IBankRepository repo)
        {
            e_repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult<List<Bank>>> GetBanks()
        {
            var banks = await e_repo.GetBanksAsync();

            return Ok(banks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBanks(int id)
        {
            var banks = await e_repo.GetBankByIdAsync(id);

            return Ok(banks);
        }

    }
}