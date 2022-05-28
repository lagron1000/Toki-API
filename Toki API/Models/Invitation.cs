namespace Toki_API.Models
{
    public class Invitation
    {
        public string from { get; set; }
        public string to { get; set; }

        public string server { get; set; }

        //public Invitation(string toId, string fromId, string fromServer)
        //{
        //    this.from = fromId;
        //    this.to = toId;
        //    this.server = fromServer;
        //}
    }
}
