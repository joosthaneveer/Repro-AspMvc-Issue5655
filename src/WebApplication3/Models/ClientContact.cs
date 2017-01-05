using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ClientContact
    {
        public ClientContact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
