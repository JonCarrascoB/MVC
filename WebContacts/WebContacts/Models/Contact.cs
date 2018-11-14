using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebContacts.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
    }
}
