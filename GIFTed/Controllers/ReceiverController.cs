using System;
using System.Collections.Generic;
using GIFTed.Data;
using GIFTed.Models;
using GIFTed.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GIFTed.Controllers
{
    public class ReceiverController : Controller
    {
        public IActionResult About()
        {
            List<Receivers> receivers = new List<Receivers>(ReceiverData.GetAll());
            return View(receivers);
        }

        [HttpGet("/Add")]
        public IActionResult Add()
        {
            AddReceiverViewModel addReceiverViewModel = new AddReceiverViewModel();
            return View(addReceiverViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddReceiverViewModel addReceiverViewModel)
        {
            Receivers newReceiver = new Receivers
            {
                Name = addReceiverViewModel.Name
            };
            ReceiverData.Add(newReceiver);

            return Redirect("/About");
        }


        public ReceiverController()
        {
        }
    }
}
