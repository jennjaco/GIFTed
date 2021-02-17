using System;
using System.Collections.Generic;
using System.Linq;
using GIFTed.Data;

namespace GIFTed.Models
{
    public class Receivers
    {
        private ReceiversDbContext context;

        public Receivers(ReceiversDbContext dbContext)
        {
            context = dbContext;
        }


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

        public Receivers(string name, string address, string contactemail, string notes, List<Gift>  gifts)
        {
            Name = name;
            Address = address;
            ContactEmail = contactemail;
            Notes = notes;
            gifts = context.Gift
                .Where(g => g.ReceiverId == Id)
                .ToList();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
