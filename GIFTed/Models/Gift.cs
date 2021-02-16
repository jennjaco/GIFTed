using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIFTed.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public string GiftName { get; set; }
        public float Cost { get; set; }
        public string Link { get; set; }

        public Receivers Receiver { get; set; }
        public int ReceiverId { get; set; }

        public Gift(string giftName, float cost, string link)
        {
            GiftName = giftName;
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
