using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GIFTed.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GIFTed.ViewModels
{
    public class AddGiftViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Input a name for the gift")]
        public string Name { get; set; }

        public float Cost { get; set; }
        public string Link { get; set; }


        public int ReceiverId { get; set; }

        public List<SelectListItem> Receivers { get; set; }

        public AddGiftViewModel(List<Receivers> receivers)
        {
            Receivers = new List<SelectListItem>();

            foreach (var rec in receivers)
            {
                Receivers.Add(
                    new SelectListItem
                    {
                        Value = rec.Id.ToString(),
                        Text = rec.Name
                    }
                 ); ;
            }
        }



        public AddGiftViewModel()
        {
        }
    }
}
