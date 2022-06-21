using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Toki_API.Models;

namespace Toki_API
{
    public class UsersContext : DbContext
    {
        private const string connectionString = "server=localhost;port=3306;database=Users;user=root;password=123";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().HasMany<Contact>(e => e.ContactList);

            modelBuilder.Entity<Contact>().HasKey(e => new { e.intId , e.ContactHolderId});
            modelBuilder.Entity<Contact>().HasMany<Message>(e => e.Messages);
            //modelBuilder.Entity<Contact>().HasAlternateKey(e => e.ContactHolderId);
            //modelBuilder.Entity<Contact>().HasOne(e => e.ContactHolder);

            modelBuilder.Entity<Message>().HasKey(e => new { e.Id, e.ChatId, e.Created });

            //modelBuilder.Entity<Message>()
            //.Property(p => p.Id)
            //.ValueGeneratedNever();

            // modelBuilder.Entity<Message>()
            //.Property(p => p.ChatId)
            //.ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User>? UsersDB { get; set; }
        public virtual DbSet<Contact>? ContactsDB { get; set; }
        public virtual DbSet<Message>? MessagesDB { get; set; }

    }
}
