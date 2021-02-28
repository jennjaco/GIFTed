using System;
using System.Collections.Generic;
using System.Linq;
using GIFTed.Areas.Identity.Data;
using GIFTed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GIFTed.Models
{
    public class Receivers
    {
        private UserManager<GIFTedUser> userManager;
        private ReceiversDbContext context;

        public Receivers(UserManager<GIFTedUser> usrMgr, ReceiversDbContext dbContext)
        {
            userManager = usrMgr;
            context = dbContext;
        }


        public int Id { get; set; }
        public string Name { get; set; }

        
        public DateTime Birthday { get; set; }

        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public RelationshipType Type { get; set; }
        public string Notes { get; set; }

        public List<Gift> gifts { get; set; }

        
        public string UserId { get; set; }

        public Receivers()
        {
        }

        public Receivers(string name, DateTime birthday, string address, string contactemail, string notes, List<Gift> gifts)
        {
            Name = name;
            Birthday = birthday;
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
