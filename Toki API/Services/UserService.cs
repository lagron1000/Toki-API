using Toki_API.Models;

namespace Toki_API.Services
{
    public class UserService
    {
        private string signedIn = "linor";
        private static List<User> users = new List<User>() {
            new User("linor", "Linor Agmon", "123", new List<Contact>()),
            new User("liron", "Liron Agnon", "123", new List<Contact>())

        };

        public string getSignedInId()
        {
            return signedIn;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }


        public User newUser(string userName, string fullName, string password)
        {
            //int id = users.Max(u => u.Id) + 1;
            List<Contact> contacts = new List<Contact>();
            User user = new User(userName, fullName, password, contacts);
            users.Add(user);
            return user;
        }


        public User? GetById(string id)
        {
            return users.Find(x => x.Id == id);
        }

        public Contact? GetContactById(string myId, string hisId)
        {
            User? me = users.Find(x => x.Id == myId);
            if (me != null) return me.ContactList.Find(x => x.Id == hisId);
            return null;
        }

        public List<Contact>? getContactsById(string id)
        {
            User? u = users.Find(x => x.Id == id);
            if (u != null) return u.ContactList;
            return null;
        }
    }
}
