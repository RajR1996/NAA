using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;

namespace NAA.Controllers
{
    [RequireHttps]
    public class AdminController : Controller
    {
        private NAA.Services.IService.IProfileService _profileService;
        private NAA.Services.IService.IApplicationService _applicationService;
        private NAA.Services.IService.IUniversityService _universityService;

        public AdminController()
        {
            _profileService = new NAA.Services.Service.ProfileService();
            _applicationService = new NAA.Services.Service.ApplicationService();
            _universityService = new NAA.Services.Service.UniversityService();
        }


        // Homepage for Admins
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }


        // GET: Admin/Create
        [Authorize(Roles = "Applicant")]
        public ActionResult CreateProfile(string UserId, string Email)
        {            
            System.Web.HttpContext.Current.Session["Id"] = UserId;
            System.Web.HttpContext.Current.Session["EmailAddress"] = Email;
            return View();
        }

        
        // POST: Admin/Create
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult CreateProfile(Profile profile)
        {
            try
            {
                _profileService.CreateProfile(profile);

                return RedirectToAction("GetProfile", new { controller = "Profile", id = profile.ApplicantId });
            }
            catch
            {
                return View();
            }
        }


        // GET: Profile/Edit/5
        [Authorize(Roles = "Applicant")]
        public ActionResult EditProfile(int id)
        {
            return View(_profileService.GetProfile(id));
        }

        
        // POST: Profile/Edit/5 
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult EditProfile(int id, Profile profile)
        {
            try
            {
                _profileService.EditProfile(profile);
                return RedirectToAction("GetProfile", new { controller = "Profile", id = profile.ApplicantId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Create
        [Authorize(Roles = "Applicant")]
        public ActionResult CreateApplication(int ApplicantId, int UniversityId, string CourseName)
        {
            ViewBag.ApplicantId = ApplicantId;
            ViewBag.UniversityId = UniversityId;
            ViewBag.CourseName = CourseName;
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult CreateApplication(Application application)
        { 
            try
            {
                _applicationService.CreateApplication(application);

                return RedirectToAction("GetOneApplication", new { controller = "Application", ApplicationId = application.ApplicationId });
            }
            catch
            {
                return View("Error", "Shared");
            }
        }

        // GET: Application/Edit/5
        [Authorize(Roles = "Applicant")]
        public ActionResult EditApplication(int ApplicationId)
        {
            return View(_applicationService.GetOneApplication(ApplicationId));
        }

        // POST: Application/Edit/5 - - Used to Firm an Application
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult EditApplication(int ApplicationId, Application application)
        {
            try
            {
                _applicationService.EditApplication(application);

                return RedirectToAction("GetOneApplication", new { controller = "Application", ApplicationId = application.ApplicationId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Applicant")]
        public ActionResult DeleteApplication(int ApplicationId)
        {
            Application application;
            application = _applicationService.GetOneApplication(ApplicationId);
            return View(application);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult DeleteApplication(int ApplicationId, Application application)
        {
            try
            {
                Application _application;
                _application = _applicationService.GetOneApplication(application.ApplicationId);
                _applicationService.DeleteApplication(_application);
                return RedirectToAction("GetMyApplications", new { controller = "Application", action ="GetMyApplications", ApplicantId = _application.ApplicantId } );
            }
            catch
            {
                return View();
            }
        }



        // GET: University/Create
        [Authorize(Roles = "Staff, Admin")]
        public ActionResult CreateUniversity()
        {
            return View();
        }

        //// POST: University/Create
        [HttpPost]
        [Authorize(Roles = "Staff, Admin")]
        public ActionResult CreateUniversity(University university)
        {
            try
            {
                _universityService.CreateUniversity(university);

                return RedirectToAction("GetUniversityList", new { controller = "University" });
            }
            catch
            {
                return View();
            }
        }

        //// GET: University/Edit/5
        [Authorize(Roles = "Staff, Admin")]
        public ActionResult EditUniversity(int UniversityId)
        {
            return View(_universityService.GetOneUniversity(UniversityId));
        }

        //// POST: University/Edit/5
        [HttpPost]
        [Authorize(Roles = "Staff, Admin")]
        public ActionResult EditUniversity(int UniversityId, University university)
        {
            try
            {
                _universityService.EditUniversity(university);

                return RedirectToAction("GetUniversityList", new { controller="University" });
            }
            catch
            {
                return View();
            }
        }

        //// GET: University/Delete/5
        [Authorize(Roles = "Staff, Admin")]
        public ActionResult DeleteUniversity(int UniversityId)
        {
            University university;
            university = _universityService.GetOneUniversity(UniversityId);
            return View(university);
        }

        //// POST: University/Delete/5
        [HttpPost]
        [Authorize(Roles = "Staff, Admin")]
        public ActionResult DeleteUniversity(int UniversityId, University university)
        {
            try
            {
                University _university;
                _university = _universityService.GetOneUniversity(university.UniversityId);
                _universityService.DeleteUniversity(_university);
                return RedirectToAction("GetUniversityList", new { controller="University" });
            }
            catch
            {
                return View();
            }
        }

    }
}
