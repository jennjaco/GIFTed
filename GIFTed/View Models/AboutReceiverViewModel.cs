using System;
using System.Collections.Generic;
using GIFTed.Models;
using System.ComponentModel.DataAnnotations;
using GIFTed.Data;
namespace GIFTed.ViewModels
{
    public class AboutReceiverViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public static DateTime Today = DateTime.Today;
        public DateTime NextBirthday { get; set; }
        public int Countdown { get; set; }

        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public RelationshipType Type { get; set; }
        public string Notes { get; set; }


        public string GiftName { get; set; }
        public float Cost { get; set; }
        public string Link { get; set; }

        public int ReceiverId { get; set; }

        public List<Gift> gifts { get; set; }

        public AboutReceiverViewModel(Receivers receiver)
        {
            Id = receiver.Id;
            Name = receiver.Name;
            Birthday = receiver.Birthday;
            NextBirthday = receiver.NextBirthday;
            Countdown = (receiver.NextBirthday - Today).Days;
            Address = receiver.Address;
            ContactEmail = receiver.ContactEmail;
            Type = receiver.Type;
            Notes = receiver.Notes;

            gifts = receiver.gifts;

        }


    }
}
