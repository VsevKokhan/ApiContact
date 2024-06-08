using Domain;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContactService:IContactService
    {
        private readonly ContactContext context;

        public ContactService(ContactContext context)
        {
            this.context = context;
        }
        public IEnumerable<Contact> GetAll()
        {
            return context.Contacts.ToList();
        }
        public Contact? GetById(int id)
        {
            return context.Find<Contact>(id);
        }
        public Contact Add(Contact contact)
        {
            context.Add(contact);
            Save();
            return contact;
        }
        public Contact Update(Contact contact)
        {
            context.Update(contact);
            return contact;
        }
        public void Delete(int id)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                Save();
            }
        }
        public void Save() 
        {
            context.SaveChanges();
        }
    }
}
