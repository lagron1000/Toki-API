using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toki_API.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intId { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string ContactHolderId { get; set; }
        //public User ContactHolder { get; set; }

        public string Name { get; set; }
        public string Server { get; set; }
        public string? last { get; set; } = null; 
        public DateTime? lastdate { get; set; } = null;
        public Message? lastmsg { get; set; } = null;
        //public string? myId { get; set; }

        [ForeignKey("Id,ChatId")]
        public ICollection<Message>? Messages { get; set; } = new List<Message>();

        //public Contact(string id, string name, string server)
        //{
        //    Id = id;
        //    Name = name;
        //    Server = server;
        //    Messages = new List<Message>();
        //}
/*        public Contact(string id, string name, string server, string _myId)
        {
            Id = id;
            Name = name;
            Server = server;
            Messages = new List<Message>();
            myId = _myId;
        }*/


    }
}
