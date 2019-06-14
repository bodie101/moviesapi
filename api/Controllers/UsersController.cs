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
   public class UsersController : ControllerBase
   {

       private readonly DB_6215_19_S1 _context;

       public UsersController(DB_6215_19_S1 context)
       {
           _context = context;
       }

       //Get
       [HttpGet]
       public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
       {
           return await _context.Users.ToListAsync();
       }
       // GET api/values
       [HttpGet("{id}")]
       public async Task<ActionResult<Users>> GetUsers(int id)
       {
           Users item = await _context.Users.FindAsync(id);

           if (item == null)
           {
               return NotFound();
           }

           return item;
       }

    
       [HttpPut("{id}")]
       public async Task<IActionResult> PutUsers(int id, Users item)
       {
           if (id != item.Id)
           {
               return BadRequest();
           }

           _context.Entry(item).State = EntityState.Modified;
           await _context.SaveChangesAsync();

           return Content("User has been updated");
       }
   }
}


