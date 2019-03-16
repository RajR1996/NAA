using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class UniversityDAO :IUniversityDAO
    {
        private NAAEntities _context;
        public UniversityDAO()
        {
            _context = new NAAEntities();
        }

        // Get list of universities for applicant when creating application
        public IList<University> GetUniversities()
        {
            IQueryable<University> _universities;
            _universities = from University
                            in _context.University
                            select University;
            return _universities.ToList<University>();
        }

        // List of universities for staff
        public IList<University> GetUniversityList()
        {
            IQueryable<University> _universities;
            _universities = from University
                            in _context.University
                            select University;
            return _universities.ToList<University>();
        }

        public University GetOneUniversity(int UniversityId)
        {
            IQueryable<University> _university;
            _university = from University
                          in _context.University
                          where University.UniversityId == UniversityId
                          select University;
            return _university.First();
        }

        public void EditUniversity(University university)
        {
            University uni = GetOneUniversity(university.UniversityId);

            uni.UniversityName = university.UniversityName;

            _context.SaveChanges();
        }

        public void CreateUniversity(University university)
        {
            _context.University.Add(university);
            _context.SaveChanges();
        }

        public void DeleteUniversity(University university)
        {
            _context.University.Remove(university);
            _context.SaveChanges();
        }
    }
}
