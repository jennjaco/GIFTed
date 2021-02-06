using System;
using System.ComponentModel.DataAnnotations;

namespace GIFTed.ViewModels
{
    public class AddReceiverViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public AddReceiverViewModel()
        {
       
        }
    }
}
