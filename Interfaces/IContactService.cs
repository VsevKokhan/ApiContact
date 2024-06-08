using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact? GetById(int id);
        Contact Add(Contact contact);
        Contact Update(Contact contact);
        void Delete(int id);
    }
}
