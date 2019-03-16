using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    [RequireHttps]
    public class UniversityController : Controller
    {
        private NAA.Services.IService.IUniversityService _universityService;
        public UniversityController()
        {
            _universityService = new NAA.Services.Service.UniversityService();
        }

        [Authorize(Roles = "Applicant")]
        // GET: University List for Applicants
        public ActionResult GetUniversities(int ApplicantId)
        {
            ViewBag.ApplicantId = ApplicantId;
            return View(_universityService.GetUniversities());
        }

        [Authorize(Roles = "Staff, Admin")]
        // GET: University List for Staff
        public ActionResult GetUniversityList()
        {
            return View(_universityService.GetUniversityList());
        }
    }
}
