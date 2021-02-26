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
                    GiftName = addGiftViewModel.GiftName,
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

      
        public IActionResult Delete(int Id)
        {
            Gift theGift = context.Gift.Find(Id);
            context.Gift.Remove(theGift);
            context.SaveChanges();
            return Redirect("/Gift");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Gift editGift = context.Gift.Find(Id);
            List<Receivers> receivers = context.Receivers.ToList();
            AddGiftViewModel addGiftViewModel = new AddGiftViewModel(receivers)
            {
                GiftName = editGift.GiftName,
                Cost = editGift.Cost,
                Link = editGift.Link,
                ReceiverId = editGift.ReceiverId,
 
            };
            return View(addGiftViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int Id, [Bind("GiftName,Cost,Link")] AddGiftViewModel addGiftViewModel)
        {
            Gift theGift = context.Gift.Find(Id);
            Receivers theReceiver = context.Receivers.Find(theGift.ReceiverId);

            if (ModelState.IsValid)
            {
                theGift.GiftName = addGiftViewModel.GiftName;
                theGift.Cost = addGiftViewModel.Cost;
                theGift.Link = addGiftViewModel.Link;
                theGift.Receiver = theReceiver;

                context.Update(theGift);
                context.SaveChanges();
            }
            return Redirect("/Gift");
        }


    }
}
