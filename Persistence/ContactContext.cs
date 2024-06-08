using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Persistence
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
    }
    
}
