using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Essentially the url will be x/api/users - This is because the name of the controller is Users(Controller)
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            /* var users = _context.Users.ToList();

            return users; */

            // Just eturn the results of the database without declaring a 
            // variable if you are not doing anything with the variable
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")] // api/users/{id}
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}