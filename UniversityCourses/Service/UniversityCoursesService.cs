using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourses.Service
{
    public class UniversityCoursesService : UniversityCourses.IService.IUniversityCoursesService
    {
        private SHU.SHUWebService _SHUproxy;
        private Sheffield.SheffieldWebService _Sheffproxy;

        public UniversityCoursesService()
        {
            _SHUproxy = new UniversityCourses.SHU.SHUWebService();
            _Sheffproxy = new UniversityCourses.Sheffield.SheffieldWebService();
        }

        public IList<UniversityCourses.SHU.SHUCourseShort> GetSHUCoursesShort()
        {
            return _SHUproxy.SHUCoursesInShort();
        }

        public IList<UniversityCourses.Sheffield.SSheffCourse> GetSheffCoursesShort()
        {
            return _Sheffproxy.SheffCoursesInShort();
        }

    }
}
