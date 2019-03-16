using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    [RequireHttps]
    public class ApplicationController : Controller
    {
        private NAA.Services.IService.IApplicationService _applicationService;
        public ApplicationController()
        {
            _applicationService = new NAA.Services.Service.ApplicationService();
        }

        // GET: Application - Old Version of GetMyApplications
        //public ActionResult GetMyApplications(int ApplicantId)
        //{
        //    ViewBag.ApplicantId = ApplicantId;
        //    return View(_applicationService.GetMyApplications(ApplicantId));
        //}

        [Authorize(Roles = "Applicant")]
        public ActionResult GetMyApplications(int ApplicantId)
        {
            ViewBag.ApplicantId = ApplicantId;
            return View(_applicationService.GetMyApplications(ApplicantId));
        }


        // GET: Application/Details/5
        [Authorize(Roles = "Applicant")]
        public ActionResult GetOneApplication(int ApplicationId)
        {
            return View(_applicationService.GetOneApplication(ApplicationId));
        }

    }
}
