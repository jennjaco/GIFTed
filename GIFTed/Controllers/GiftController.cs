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
    public class GiftController : Controller
    {
        private ReceiversDbContext context;

        public GiftController(ReceiversDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Gift> gifts = context.Gift.Include(e => e.Receiver).ToList();
            return View(gifts);
        }

        public IActionResult Add()
        {
            List<Receivers> receivers = context.Receivers.ToList();
            AddGiftViewModel addGiftViewModel = new AddGiftViewModel(receivers);
            return View(addGiftViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGiftViewModel addGiftViewModel)
        {
            if (ModelState.IsValid)
            {
                Receivers theReceiver = context.Receivers.Find(addGiftViewModel.ReceiverId);
                Gift newGift = new Gift
                {
                    Name = addGiftViewModel.Name,
                    Cost = addGiftViewModel.Cost,
                    Link = addGiftViewModel.Link,
                    Receiver = theReceiver,
                };

                context.Gift.Add(newGift);
                context.SaveChanges();

                return Redirect("/Gift");
            }

            return View(addGiftViewModel);
        }

    }
}
