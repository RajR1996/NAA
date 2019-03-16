using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    [RequireHttps]
    public class ProfileController : Controller
    {
        private NAA.Services.IService.IProfileService _profileService;
        public ProfileController()
        {
            _profileService = new NAA.Services.Service.ProfileService();
        }

        [Authorize(Roles = "Applicant")]
        // GET: Profile - gets a profile using their ApplicantId
        public ActionResult GetProfile(int id)
        {
            // If the ApplicantId is stored in the session then use it as the parameter to get profile
            System.Web.HttpContext.Current.Session["Id"] = id;
            return View(_profileService.GetProfile(id));
        }

    }
}
