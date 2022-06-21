using Microsoft.AspNetCore.Mvc;
using Toki_API.Models;
using Toki_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toki_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly IUserService uService = new DbUserService();

        // GET: api/<InvitationsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InvitationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvitationsController>
        [HttpPost]
        public IActionResult SendInvite([Bind(
            nameof(Invitation.from),
            nameof(Invitation.to),
            nameof(Invitation.server))] Invitation inv)
        {
            User? toUser = uService.GetById(inv.to);
            if (toUser == null) return NotFound(ConstService.NO_USR);
            Contact c = new Contact();
            c.Id = inv.from;
            c.ContactHolderId = inv.to;
            //c.ContactHolder = toUser;
            c.Name = inv.from;
            c.Server = inv.server;
            //toUser.addContact(new Contact(inv.from, inv.from, inv.server, inv.to));
            //toUser.addContact(c);
            uService.newContact(toUser.Id, c);
            return Ok();
        }

        // PUT api/<InvitationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvitationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
