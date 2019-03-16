using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class StudentApplicationBEAN
    {
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UniversityName { get; set; }
        public string CourseName { get; set; }
        public string PersonalStatement { get; set; }
        public string TeachReference { get; set; }
        public string TeacherContactDetails { get; set; }
        public string UniversityOffer { get; set; }
        public bool? Firm { get; set; }

    }
}
