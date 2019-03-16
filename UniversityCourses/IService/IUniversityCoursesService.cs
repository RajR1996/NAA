using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourses.IService
{
    interface IUniversityCoursesService
    {
        IList<UniversityCourses.SHU.SHUCourseShort> GetSHUCoursesShort();

        IList<UniversityCourses.Sheffield.SSheffCourse> GetSheffCoursesShort();

    }
}
