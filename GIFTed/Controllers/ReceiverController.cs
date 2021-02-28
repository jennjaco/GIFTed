using System;
using System.Collections.Generic;
using System.Linq;
using GIFTed.Data;
using GIFTed.Models;
using GIFTed.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GIFTed.Areas.Identity.Data;

namespace GIFTed.Controllers
{
    [Authorize]
    public class ReceiverController : Controller
    {
        private UserManager<GIFTedUser> userManager;
        private ReceiversDbContext context;

        public ReceiverController(UserManager<GIFTedUser> usrMgr, ReceiversDbContext dbContext)
        {
            userManager = usrMgr;
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Receivers> receivers = context.Receivers.Where(i => i.UserId == userManager.GetUserAsync(User).Result.Id).ToList();
            foreach (var item in receivers.ToList())
            {

                receivers.Add(item);
                //try
                //{
                //    if (item.UserId.Equals(userManager.GetUserAsync(User).Result.Id))
                //    {
                //        receivers.Add(item);
                //    }
                //}
                //catch (NullReferenceException)
                //{
                //    return Redirect("/Receiver/Add");
                //}

               
            }

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
                    UserId = userManager.GetUserAsync(User).Result.Id,
                };

                context.Receivers.Add(newReceiver);
                context.SaveChanges();

                return Redirect("/Receiver");
            }
            return View(addReceiverViewModel);
        }

        public IActionResult Delete(int Id)
        {
            Receivers theReceiver = context.Receivers.Find(Id);
            context.Remove(theReceiver);
            context.SaveChanges();

            return Redirect("/Receiver");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Receivers theReceiver = context.Receivers.Find(Id);
            AddReceiverViewModel addReceiverViewModel = new AddReceiverViewModel
            {
                Name = theReceiver.Name,
                Birthday = theReceiver.Birthday,
                ContactEmail = theReceiver.ContactEmail,
                Address = theReceiver.Address,
                Type = theReceiver.Type,
                Notes = theReceiver.Notes,
            };

            return View(addReceiverViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int Id, [Bind("Id,Name,Birthday,ContactEmail,Address,Type,Notes")] AddReceiverViewModel addReceiverViewModel)
        {
            Receivers receiver = context.Receivers.Find(Id);

            if (ModelState.IsValid)
            {
                receiver.Name = addReceiverViewModel.Name;
                receiver.Birthday = addReceiverViewModel.Birthday;
                receiver.ContactEmail = addReceiverViewModel.ContactEmail;
                receiver.Address = addReceiverViewModel.Address;
                receiver.Type = addReceiverViewModel.Type;
                receiver.Notes = addReceiverViewModel.Notes;


                context.Update(receiver);
                context.SaveChanges();

            }
            
            return Redirect("/Receiver");
        }
            


    }
}
