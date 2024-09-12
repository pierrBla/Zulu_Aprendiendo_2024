using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zulu.Api.Data;
using Zulu.Shared.Entities;

namespace Zulu.Api.Controllers
{
    //para que sea controlador ApiController,Route
    //eredar :controllerBase
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController:ControllerBase
    {
        private readonly DataContext _context;

        //creamos ctor =controllador inyectamos DataContext context
        //context le decimos que cree el  campo  ctrol .
        public CountriesController(DataContext context)
        {
            _context = context;
        }
        //ActionResult son repuestas del  http

        [HttpPost]
        public async Task<ActionResult> Postsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
                return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> Getsync()
        {
            
            return Ok(await _context.Countries.ToListAsync());
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Getsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x=>x.Id ==id);
            if(country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> Putsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletesync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
