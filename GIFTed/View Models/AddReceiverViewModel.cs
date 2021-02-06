using System;
using System.ComponentModel.DataAnnotations;

namespace GIFTed.ViewModels
{
    public class AddReceiverViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }



        public AddReceiverViewModel()
        {
       
        }
    }
}
