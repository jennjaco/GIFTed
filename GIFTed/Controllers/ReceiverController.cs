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
    public class ReceiverController : Controller
    {
        private ReceiversDbContext context;

        public ReceiverController(ReceiversDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Receivers> receivers = context.Receivers.ToList();


            return View(receivers);
        }

     
        public IActionResult Add()
        {
            AddReceiverViewModel addReceiverViewModel = new AddReceiverViewModel();
            return View(addReceiverViewModel);
        }



        [HttpPost]
        public IActionResult Add(AddReceiverViewModel addReceiverViewModel)
        {
            if (ModelState.IsValid)
            {
                Receivers newReceiver = new Receivers
                {
                    Name = addReceiverViewModel.Name,
                    Address = addReceiverViewModel.Address,
                    ContactEmail = addReceiverViewModel.ContactEmail,
                    Type = addReceiverViewModel.Type,
                    Notes = addReceiverViewModel.Notes,
                };

                context.Receivers.Add(newReceiver);
                context.SaveChanges();

                return Redirect("/Receiver");
            }
            return View(addReceiverViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.receivers = context.Receivers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] recIds)
        {
            foreach (int recId in recIds)
            {
                Receivers theReceiver = context.Receivers.Find(recId);
                context.Receivers.Remove(theReceiver);
            }

            context.SaveChanges();
            return Redirect("/Receiver");
        }

        //public IActionResult About(int id)
        //{
            //List<Receivers> receiver = context.Receivers.Include(g => g.gifts).ToList();


            //Is this even where about needs to be? Is it going to use the gift's id or the receiver's id? I want it to
            //use the receiver id, but also list the gifts that have receiver id assigned as a foreign key

        //    return View(receiver);
        //}

    }
}
