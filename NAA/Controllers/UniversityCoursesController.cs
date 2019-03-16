using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.Controllers
{
    [RequireHttps]
    public class UniversityCoursesController : Controller
    {
        private UniversityCourses.Service.UniversityCoursesService _uniCourseService;
        public UniversityCoursesController()
        {
            _uniCourseService = new UniversityCourses.Service.UniversityCoursesService();
        }

        [Authorize(Roles = "Applicant")]
        //GET: UniversityCourses
        public ActionResult GetUniversityCoursesShort(int ApplicantId, int UniversityId)
        {
            
            if (UniversityId == 0)
            {
                ViewBag.ApplicantId = ApplicantId;
                ViewBag.UniversityId = UniversityId;
                return RedirectToAction("ViewSHUCoursesShort", new { controller = "UniversityCourses", ViewBag.ApplicantId, ViewBag.UniversityId });
            }
            else if (UniversityId == 1)
            {
                ViewBag.ApplicantId = ApplicantId;
                ViewBag.UniversityId = UniversityId;
                return RedirectToAction("ViewSheffCoursesShort", new { controller = "UniversityCourses", ViewBag.ApplicantId, ViewBag.UniversityId });
            }
            else
            {
                return View("Error");
            }

        }

        [Authorize(Roles = "Applicant")]
        public ActionResult ViewSHUCoursesShort(int ApplicantId, int UniversityId)
        {
            ViewBag.ApplicantId = ApplicantId;
            ViewBag.UniversityId = UniversityId;
            return View(_uniCourseService.GetSHUCoursesShort());
        }

        [Authorize(Roles = "Applicant")]
        public ActionResult ViewSheffCoursesShort(int ApplicantId, int UniversityId)
        {
            ViewBag.ApplicantId = ApplicantId;
            ViewBag.UniversityId = UniversityId;
            return View(_uniCourseService.GetSheffCoursesShort());
        }

    }
}