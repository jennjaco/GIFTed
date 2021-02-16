using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GIFTed.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GIFTed.ViewModels
{
    public class AddReceiverViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }


        public RelationshipType Type { get; set; }

        public List<SelectListItem> RelationshipTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(RelationshipType.Family.ToString(), ((int)RelationshipType.Family).ToString()),
            new SelectListItem(RelationshipType.Friend.ToString(), ((int)RelationshipType.Friend).ToString()),
            new SelectListItem(RelationshipType.CoWorker.ToString(), ((int)RelationshipType.CoWorker).ToString()),
            new SelectListItem(RelationshipType.Aquaintance.ToString(), ((int)RelationshipType.Aquaintance).ToString()),
        };

        public string Notes { get; set; }

        public AddReceiverViewModel()
        {

        }
    }
}