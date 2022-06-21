using Microsoft.AspNetCore.Mvc;
using Toki_API.Models;
using Toki_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toki_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IUserService uService = new DbUserService();

        // GET: api/<TransferController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransferController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransferController>
        [HttpPost]
        public void recieveMessage([Bind(nameof(Transfer.from), nameof(Transfer.to), nameof(Transfer.content))] Transfer m)
        {
            Contact? reciever = uService.GetContactById(m.to, m.from);
            if (reciever == null) return;
            int newId = 0;
            if (reciever.Messages.Count != 0) newId = (reciever.Messages
                    .Max(u => u.Id) + 1);
            DateTime now = DateTime.Now;
            Message newMsg = new Message();
            //newMsg.Id = newId;
            newMsg.Content = m.content;
            newMsg.Created = now;
            newMsg.Sent = false;
            newMsg.SentBy = m.from;
            newMsg.ChatId = m.from;
            uService.newMessage(reciever, newMsg);
            //reciever.Messages.Add(newMsg);
            //reciever.last = m.content;
            //reciever.lastdate = now;
            //reciever.lastmsg = newMsg;
        }

        // PUT api/<TransferController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
