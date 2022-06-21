using Toki_API.Models;

namespace Toki_API.Services
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>() {
            //new User("linor", "Linor Agmon", "123", new List<Contact>()),
            //new User("liron", "Liron Agnon", "123", new List<Contact>())

        };

        public List<User> GetAllUsers()
        {
            return users;
        }


        public User newUser(string userName, string fullName, string password)
        {
            //int id = users.Max(u => u.Id) + 1;
            List<Contact> contacts = new List<Contact>();
            User user = new User();
            user.Id = userName; user.Name = fullName; user.Password = password; user.ContactList = contacts;
            //User user = new User(userName, fullName, password, contacts);
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
            if (me != null) return me.ContactList.ToList().Find(x => x.Id == hisId);
            return null;
        }

        public ICollection<Contact>? getContactsById(string id)
        {
            User? u = users.Find(x => x.Id == id);
            if (u != null) return u.ContactList;
            return null;
        }

        public void newContact(string myId, Contact c)
        {
            User? u = GetById(myId);
            u.ContactList.Add(c);
        }

        public void newMessage(Contact c, Message msg)
        {
            c.Messages.Add(msg);
            c.last = msg.Content;
            c.lastdate = msg.Created;
            //c.lastmsg = msg;
        }
    }
}
