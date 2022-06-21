using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toki_API.Models
{
    public class User
    {
        [Required]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        public string server { get; set; } = "localhost:5143";
        [ForeignKey("ContactHolderId")]
        public ICollection<Contact> ContactList {get; set;}

        //public User(string id, string name, string password, List<Contact> contacList)
        //{
        //    Id = id;
        //    Name = name;
        //    Password = password;
        //    ContactList = contacList;
        //    server = "localhost:5143";
        //}
        //public void addContact(Contact c)
        //{
        //    ContactList.Add(c);
        //}
    }
}
