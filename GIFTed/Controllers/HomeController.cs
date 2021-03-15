using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GIFTed.Models;
using GIFTed.ViewModels;
using GIFTed.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GIFTed.Areas.Identity.Data;

namespace GIFTed.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<GIFTedUser> userManager;
        private ReceiversDbContext context;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<GIFTedUser> usrMgr, ReceiversDbContext dbContext)
        {
            _logger = logger;
            userManager = usrMgr;
            context = dbContext;
        }

        public IActionResult Index()
        {
            
            List<Receivers> receivers = context.Receivers
                .Where(x => x.UserId == userManager.GetUserId(User))
                .ToList();

            return View(receivers);
        }


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
