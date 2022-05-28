using Microsoft.AspNetCore.Mvc;
using Toki_API.Services;
using Toki_API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toki_API.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly UserService uService = new UserService();
        //private readonly ChatService cService = new ChatService();


        // GET: api/<ContactsController>

        // GET: Contacts
        [HttpGet]
        public IActionResult Get(string signedId)
        {
            string signedInId = signedId;
            ICollection<Contact>? contacts = uService.getContactsById(signedInId);
            if (contacts == null) return NotFound(ConstService.NO_CON);
            return Ok(contacts);
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id, string signedId)
        {
            string signedInId = signedId;
            Contact? x = uService.GetContactById(signedInId, id);
            if (x == null) return NotFound(ConstService.NO_CON);
            return Ok(x);
        }

        // POST api/<ContactsController>

        [HttpPost]
        //public void Post([Bind(nameof(Contact.Id), nameof(Contact.Name))] Contact value) 
        //string conId, string nickname, string server, string signedId

        public IActionResult Post([Bind(nameof(MContact.Id), nameof(MContact.Name), nameof(MContact.Server))] MContact c, string signedId)
        {
            string signedInId = signedId;
            ICollection<Contact>? hisContacts = uService.getContactsById(signedInId);
            //User? conUser = uService.GetById(c.Id);
            //if (conUser == null) return NotFound(ConstService.NO_USR);
            if (uService.GetContactById(signedId, c.Id) != null) return BadRequest("Contact already added");
            Contact con = new Contact(c.Id, c.Name, c.Server, signedId);
            if (hisContacts != null) hisContacts.Add(con);
            return Ok();

        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public void Put(string id, [Bind(nameof(PContact.Name), nameof(PContact.Server))] PContact c, string signedId)
        {
            string signedInId = signedId;
            Contact? x = uService.GetContactById(signedInId, id);
            if (x == null) return;
            x.Name = c.Name;
            x.Server = c.Server;
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(string id, string signedId)
        {
            string signedInId = signedId;
            Contact? x = uService.GetContactById(signedInId, id);
            List<Contact>? contacts = uService.getContactsById(signedInId);
            if (contacts == null || x == null) return;
            contacts.Remove(x);
        }

        [HttpGet("{id}/messages")]
        public IActionResult GetMessages(string id, string signedId)
        {
            string signedInId = signedId;
            Contact? x = uService.GetContactById(signedInId, id);
            if (x == null) return NotFound(ConstService.NO_CON);
            return Ok(x.Messages);
        }

        [HttpPost("{recId}/messages")]
        public void SendMessages(string recId, [Bind(nameof(MMessage.content))] MMessage m, string signedId)
        {
            string signedInId = signedId;
            Contact? rec = uService.GetContactById(signedInId, recId);
            if (rec == null) return;
            int newId = 0;
            if (rec.Messages.Count != 0) newId = rec.Messages.Max(u => u.Id) + 1;
            DateTime now = DateTime.Now;
            Message newMsg = new Message(newId, m.content, now, true, signedInId);
            rec.Messages.Add(newMsg);
            rec.last = newMsg.Content;
            rec.lastdate = newMsg.Created;
            rec.lastmsg = newMsg;
        }

        [HttpGet("{recId}/messages/{msgId}")]
        public IActionResult GetMessage(string recId, int msgId, string signedId)
        {
            string signedInId = signedId;
            Contact? rec = uService.GetContactById(signedInId, recId);
            if (rec == null) return NotFound(ConstService.NO_USR);
            if (rec.Messages.Count == 0) return NotFound(ConstService.NO_MSG);
            Message? msg = rec.Messages.Find(msg => msg.Id == msgId);
            if (msg == null) return NotFound(ConstService.NO_MSG);
            return Ok(msg);
        }
    

    [HttpPut("{recId}/messages/{msgId}")]
        public void EditMessage(string recId, int msgId, [Bind(nameof(MMessage.content))] MMessage m, string signedId)
        {
            string signedInId = signedId;
            Contact? rec = uService.GetContactById(signedInId, recId);
            if (rec == null) return;
            if (rec.Messages.Count == 0) return;
            Message? msg = rec.Messages.Find(msg => msg.Id == msgId);
            if (msg == null) return;
            msg.Content = m.content;
        }

        [HttpDelete("{recId}/messages/{msgId}")]
        public void DeleteMessage(string recId, int msgId, string signedId)
        {
            string signedInId = signedId;
            Contact? rec = uService.GetContactById(signedInId, recId);
            if (rec == null) return;
            if (rec.Messages.Count == 0) return;
            Message? msg = rec.Messages.Find(msg => msg.Id == msgId);
            if (msg == null) return;
            rec.Messages.Remove(msg);
        }

        //[HttpPost("transfer")]
        //public void recieveMessage([Bind(nameof(Transfer.from), nameof(Transfer.to), nameof(Transfer.content))] Transfer m)
        //{
        //    Contact? sender = uService.GetContactById(m.to, m.from);
        //    if (sender == null) return;
        //    int newId = 0;
        //    if (sender.Messages.Count != 0) newId = sender.Messages.Max(u => u.Id) + 1;
        //    DateTime now = DateTime.Now;
        //    Message newMsg = new Message(newId, m.content, now, false, m.from);
        //    sender.Messages.Add(newMsg);
        //}

        //[HttpPost("invitations")]
        //public IActionResult SendInvite([Bind(nameof(Invitation.from), 
        //    nameof(Invitation.to), 
        //    nameof(Invitation.server))] Invitation inv)
        //{
        //    User? toUser = uService.GetById(inv.to);
        //    if (toUser == null) return NotFound(ConstService.NO_USR);
        //    toUser.addContact(new Contact(inv.from, inv.from, inv.server, inv.to));
        //    return Ok();
        //}

    }
}
