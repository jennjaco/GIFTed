﻿using System;
using System.Collections.Generic;
using GIFTed.Models;
using GIFTed.Data;
namespace GIFTed.ViewModels
{
    public class AboutReceiverViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public RelationshipType Type { get; set; }
        public string Notes { get; set; }


        public string GiftName { get; set; }
        public float Cost { get; set; }
        public string Link { get; set; }

        public int ReceiverId { get; set; }

     

        public AboutReceiverViewModel(Receivers receiver, List<Gift> giftList)
        {
            Id = receiver.Id;
            Name = receiver.Name;
            Address = receiver.Address;
            ContactEmail = receiver.ContactEmail;
            Type = receiver.Type;
            Notes = receiver.Notes;

            

            foreach (var item in giftList)
            {
                if (item.ReceiverId == receiver.Id)
                {
                    GiftName = item.GiftName;
                    Cost = item.Cost;
                    Link = item.Link;
                }
            }
        }
    }
}