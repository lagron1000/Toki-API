using Toki_API.Models;

namespace Toki_API.Services
{
    public interface IUserService
    {

        public List<User> GetAllUsers();


        public User newUser(string userName, string fullName, string password);


        public User? GetById(string id);

        public Contact? GetContactById(string myId, string hisId);

        public ICollection<Contact>? getContactsById(string id);

        public void newContact(string myId, Contact c);
        public void newMessage(Contact c, Message msg);
    }
}
