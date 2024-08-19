using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreInventory.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public string Role { get; set; }
    }
}