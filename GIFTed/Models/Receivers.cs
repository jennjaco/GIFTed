using System;
using System.Collections.Generic;

namespace GIFTed.Models
{
    public class Receivers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public RelationshipType Type { get; set; }
        public string Notes { get; set; }

        public List<Gift> gifts { get; set; }

        public Receivers()
        {
        }

        public Receivers(string name, string address, string contactemail, string notes)
        {
            Name = name;
            Address = address;
            ContactEmail = contactemail;
            Notes = notes;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
