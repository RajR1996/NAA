using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.IDAO;
using NAA.Data.DAO;

namespace NAA.Services.Service
{
    public class UniversityService : NAA.Services.IService.IUniversityService
    {
        private IUniversityDAO _universityDAO;
        public UniversityService()
        {
            _universityDAO = new UniversityDAO();
        }

        public IList<University> GetUniversities()
        {
            return _universityDAO.GetUniversities();
        }

        public IList<University> GetUniversityList()
        {
            return _universityDAO.GetUniversityList();
        }

        public University GetOneUniversity(int UniversityId)
        {
            return _universityDAO.GetOneUniversity(UniversityId);
        }

        public void EditUniversity(University university)
        {
            _universityDAO.EditUniversity(university);
        }

        public void DeleteUniversity(University university)
        {
            _universityDAO.DeleteUniversity(university);
        }

        public void CreateUniversity(University university)
        {
            _universityDAO.CreateUniversity(university);
        }
    }
}
