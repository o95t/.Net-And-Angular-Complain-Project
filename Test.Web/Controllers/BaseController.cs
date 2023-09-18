using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public bool IsAdmin { get {

                var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var xx = userManager.FindByIdAsync(user).Result;
                return xx.IsAdmin;
            } }
    }
}
