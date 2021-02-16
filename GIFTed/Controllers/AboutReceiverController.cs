using System;
using System.Collections.Generic;
using System.Linq;
using GIFTed.Data;
using GIFTed.Models;
using GIFTed.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GIFTed.Controllers
{
    public class AboutReceiverController : Controller
    {
        private ReceiversDbContext context;

        public AboutReceiverController(ReceiversDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            Receivers receiver = context.Receivers.Find(id);

            List<Gift> giftList = context.Gift.Include(e => e.Receiver).ToList();

            AboutReceiverViewModel viewModel = new AboutReceiverViewModel(receiver, giftList);

            return View(viewModel);
        }


    }
}
