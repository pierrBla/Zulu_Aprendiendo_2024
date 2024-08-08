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
        public async Task<ActionResult> Post(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
                return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok(await _context.Countries.ToListAsync());
        }
    }
}
