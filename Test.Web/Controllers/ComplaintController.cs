using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Test.Web.Data;
using Test.Web.Models;
using static Test.Web.Data.ApplicationDbContext;

namespace Test.Web.Controllers
{
    [Route("api/complaint")]
    public class ComplaintController : ControllerBase
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> userManager;

        public ComplaintController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }
        [Route("add")]
        [HttpPost]
        public IActionResult Create([FromBody] ComplaintModel model)
        {
            if (model.Rate == null)
                model.Rate = "0";
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var xx = userManager.FindByIdAsync(user).Result;
            var complait = new Complain
            {
                Custmer = xx.UserName,
                Description = model.Description,
                Status = "1",
                Rate = Int32.Parse(model.Rate),
                MainProblem = model.MainProblem,
                Subject = model.Subject
            };
            _db.Complains.Add(complait);
            _db.SaveChanges();
            return Ok();
        }

        [Route("Get")]
        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
           var list = _db.Complains.ToList(); 
            return Ok(list);
        }
        [Route("update")]
        [HttpPost]
        public IActionResult Update(int complainId, int statusId)
        {
            var c = _db.Complains.Where(x => x.Id == complainId).FirstOrDefault();
            c.Status = statusId.ToString();
            _db.Complains.Update(c);
            _db.SaveChanges();
            return Ok();
        }
    }
}