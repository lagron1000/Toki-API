namespace Toki_API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool Sent { get; set; }

        public string SentBy { get; set; }

        public Message(int id, string content, DateTime created, bool sent, string sentBy)
        {
            Id = id;
            Content = content;
            Created = created;
            Sent = sent;
            SentBy = sentBy;
        }
    }
}
