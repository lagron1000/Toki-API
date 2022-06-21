using Microsoft.EntityFrameworkCore;
using Toki_API.Models;

namespace Toki_API.Services
{
    public class DbUserService : IUserService
    {
        public List<User> GetAllUsers()
        {
            using(var db = new UsersContext())
            {
                var users = db.UsersDB;
                if (users != null) return users.Include(x => x.ContactList).ThenInclude(x => x.Messages).ToList<User>();
                else throw new NotImplementedException();
            }
        }

        public User? GetById(string id)
        {
            using (var db = new UsersContext())
            {
                DbSet<User>? users = db.UsersDB;
                if (users == null) throw new NotImplementedException();
                return users.Include(x => x.ContactList).ThenInclude(x => x.Messages).ToList<User>().Find(u=>u.Id ==id);
            }
        }

        public Contact? GetContactById(string SaverId, string ConId)
        {
            using (var db = new UsersContext())
            {
                List<Contact> cList = db.ContactsDB.Include(c => c.Messages).ToList<Contact>();
                return cList.Find(u => u.ContactHolderId == SaverId && u.Id == ConId);
            }
        }

        public ICollection<Contact>? getContactsById(string id)
        {
            using (var db = new UsersContext())
            {
                List<Contact> cList = db.ContactsDB.Include(c => c.Messages).ToList<Contact>();
                return cList.FindAll(u => u.ContactHolderId == id);
            }
        }

        public User newUser(string userName, string fullName, string password)
        {
            using (var db = new UsersContext())
            {
                DbSet<User>? users = db.UsersDB;
                if (users == null) throw new NotImplementedException();
                User user = new User();
                List<Contact> contacts = new List<Contact>();
                user.Id = userName; user.Name = fullName; user.Password = password; user.ContactList = contacts;
                db.Add(user);
                db.SaveChanges();
                return user;
            }
        }

        public void newContact(string myId, Contact c)
        {
            using (var db = new UsersContext())
            {
                User? u = GetById(myId);
                db.Add(c);
                u.ContactList.Add(c);
                db.SaveChanges();
            }
        }

        public void newMessage(Contact c, Message msg)
        {
            using (var db = new UsersContext())
            {
                //db.Add(msg);
                var User = db.UsersDB.Include(x => x.ContactList).ThenInclude(x => x.Messages).First(x => x.Id == c.ContactHolderId);
                Contact con = User.ContactList.First(x => x.intId == c.intId);
                con.Messages.Add(msg);
                con.last = msg.Content;
                con.lastdate = msg.Created;
                con.lastmsg = msg;
                //db.SaveChanges();
                //Contact con = GetContactById(c.ContactHolderId, c.Id); 
                //c.Messages.Add(msg);
                //con.lastmsg = msg;
                db.SaveChanges();
            }
        }

        public void DeleteUser(string id)
        {
            //using (var db = new UsersContext())
            //{
            //    DbSet<User>? users = db.UsersDB;
            //    if (users == null) throw new NotImplementedException();
            //    users.Remove(X=)
            //}
        }
    }
}
