using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zulu.Api.Data;
using Zulu.Shared.Entities;

namespace Zulu.Api.Controllers
{

    [ApiController]
    [Route("/api/categories")]
    public class CategoryController:ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> Postsync(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoria con el mismo nombre");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Getsync()
        {

            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Getsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult> Putsync(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoria con el mismo nombre");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletesync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}
