using System.ComponentModel.DataAnnotations;

namespace Toki_API.Models
{
    public class Contact
    {
        //public string UserId { get; set; }
        public string Id { get; set; }
        //public string ContactId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Server { get; set; }
        public string? last { get; set; } = null; 
        public DateTime? lastdate { get; set; } = null;
        public Message? lastmsg { get; set; } = null;
        public string? myId { get; set; }

        public List<Message>? Messages { get; set; }

        //public Contact(string id, string name, string server)
        //{
        //    Id = id;
        //    Name = name;
        //    Server = server;
        //    Messages = new List<Message>();
        //}
        public Contact(string id, string name, string server, string _myId)
        {
            Id = id;
            Name = name;
            Server = server;
            Messages = new List<Message>();
            myId = _myId;
        }

    }
}
