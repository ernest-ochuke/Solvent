using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly SolventContext e_context;
        public BanksController(SolventContext context)
        {
            e_context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Bank>>> GetBanks()
        {
           var banks =await e_context.Banks.ToListAsync();

            return Ok(banks);
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBanks(int id)
        {
           var banks =await e_context.Banks.FindAsync(id);

            return Ok(banks);
        }

    }
}