using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Services.IService
{
    public interface IUniversityService
    {
        IList<University> GetUniversities();

        IList<University> GetUniversityList();

        University GetOneUniversity(int UniversityId);

        void EditUniversity(University university);

        void CreateUniversity(University university);

        void DeleteUniversity(University university);
    }
}
