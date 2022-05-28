using Microsoft.AspNetCore.Mvc;
using Toki_API.Models;
using Toki_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toki_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService uService = new UserService();

        private User signedIn;

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult GeUsers()
        {
            List<User> users = uService.GetAllUsers();
            if (users == null) return NotFound(ConstService.NO_USR);
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            User? user = uService.GetById(id);
            if (user != null) return Ok(user);
            return NotFound(ConstService.NO_USR);
        }

        // POST api/<UsersController>
        [HttpPost]

        //string id, string name, string pass Post([Bind(nameof(Contact.Id), nameof(Contact.Name))] Contact value)
        public IActionResult Post([
            Bind(nameof(MUser.Id), 
            nameof(MUser.Name), 
            nameof(MUser.Password))] MUser u)
        {
            if (uService.GetById(u.Id) != null) return BadRequest("username taken");
            uService.newUser(u.Id, u.Name, u.Password);
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
