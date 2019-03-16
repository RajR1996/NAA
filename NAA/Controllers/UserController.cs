using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NAA.Models;

namespace NAA.Controllers
{
    [RequireHttps]
    public class UserController : Controller
    {
        private NAA.Models.ApplicationDbContext _context;
        public UserController()
        {
            _context = new NAA.Models.ApplicationDbContext();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers()
        {
            return View(_context.Users.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles()
        {
            // Populate roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem
            {
                Value = rr.Name.ToString(),
                Text = rr.Name
            }).ToList();
            ViewBag.Roles = roleList;

            // Populate users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem
            {
                Value = uu.UserName.ToString(),
                Text = uu.UserName
            }).ToList();
            ViewBag.Users = userList;

            return View();
        }

        [HttpPost][ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);
            // Prepopulate roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem
            {
                Value = rr.Name.ToString(),
                Text = rr.Name
            }).ToList();
            ViewBag.Roles = roleList;

            // Prepopulate users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem
            {
                Value = uu.UserName.ToString(),
                Text = uu.UserName
            }).ToList();
            ViewBag.Users = userList;

            return View("ManageUserRoles");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesForUser()
        {
            return View();
        }

        [HttpPost][ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesForUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesForUserConfirmed");
        }

    }
}
