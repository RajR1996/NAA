using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class GetMyApplicationsBEAN
    {
        public int ApplicationId { get; set; }
        public int ApplicantId { get; set; }
        public string CourseName { get; set; }
        // The reason for this BEANS class which is to get the UniversityName instead of UniversityId
        public string UniversityName { get; set; }
        public string UniversityOffer { get; set; }
        public bool? Firm { get; set; }

        public GetMyApplicationsBEAN() { }
    }
}
