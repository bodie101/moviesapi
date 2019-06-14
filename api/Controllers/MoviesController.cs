using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MoviesController : ControllerBase
   {

       private readonly DB_6215_19_S1 _context;

       public MoviesController(DB_6215_19_S1 context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
       {
           return await _context.Movies.ToListAsync();
       }
       // GET api/values
       [HttpGet("{id}")]
       public async Task<ActionResult<Movies>> GetMovies(int id)
       {
           Movies item = await _context.Movies.FindAsync(id);

           if (item == null)
           {
               return NotFound();
           }

           return item;
       }
   }
}
