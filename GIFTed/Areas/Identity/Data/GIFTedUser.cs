using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GIFTed.Data;

namespace GIFTed.Areas.Identity.Data
{
    public class GIFTedUser : IdentityUser
    {
        [PersonalData]
        public string UserId { get; set; }
    }
}
