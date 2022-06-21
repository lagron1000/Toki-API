using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toki_API.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Key]
        public string ChatId { get; set; }
        public string Content { get; set; }
        [Key]
        public DateTime Created { get; set; }
        public bool Sent { get; set; }
        public string SentBy { get; set; }

        //public Message(int id, string content, DateTime created, bool sent, string sentBy)
        //{
        //    Id = id;
        //    Content = content;
        //    Created = created;
        //    Sent = sent;
        //    SentBy = sentBy;
        //}
    }
}
