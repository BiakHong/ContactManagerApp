using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactList : DbContext
    {
        public ContactList(DbContextOptions<ContactList> options)
        : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "F", Name = "Friend" },
                new Category { CategoryId = "W", Name = "Work" },
                new Category { CategoryId = "Fml", Name = "Family" }
            );
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    First = "Delores",
                    Last = "Del Rio",
                    Phone = "555-987-6543",
                    Email = "dores@hotmail.com",
                    CategoryId = "Fml",
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 2,
                    First = "Efren",
                    Last = "Herrera",
                    Phone = "555-456-7890",
                    Email = "efren@aol.com",
                    CategoryId = "W",
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 3,
                    First = "Marry Ellen",
                    Last = "Walton",
                    Phone = "555-123-4567",
                    Email = "MaryEllen@yahoo.com",
                    CategoryId = "F",
                    DateAdded = DateTime.Now
                });
        }
    }

}