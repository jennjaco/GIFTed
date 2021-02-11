using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIFTed.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Link { get; set; }

        public Receivers Receiver { get; set; }
        public int ReceiverId { get; set; }

        public Gift(string name, float cost, string link)
        {
            Name = name;
            Cost = cost;
            Link = link;
        }

        public Gift()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Gift gift &&
                   Id == gift.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


    }
}
