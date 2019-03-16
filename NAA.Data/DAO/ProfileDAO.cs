using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class ProfileDAO : IProfileDAO
    {
        private NAAEntities _context;
        public ProfileDAO()
        {
            _context = new NAAEntities();
        }

        // Get ApplicantID when Applicant logs in
        public int GetApplicantId(string UserId)
        {
            IQueryable<int> _applicantId;
            _applicantId = from Profile
                            in _context.Profile
                           where Profile.UserId == UserId
                           select Profile.ApplicantId;
            return _applicantId.FirstOrDefault();
        }

        // Get Applicant Profile
        public Profile GetProfile(int ApplicantId)
        {
            IQueryable<Profile> _profiles;
            _profiles = from Profile
                        in _context.Profile
                        where Profile.ApplicantId == ApplicantId
                        select Profile;
            return _profiles.First();
        }

        // Edit Applicant Profile
        public void EditProfile(Profile profile)
        {
            Profile prof = GetProfile(profile.ApplicantId);

            prof.ApplicantName = profile.ApplicantName;
            prof.ApplicantAddress = profile.ApplicantAddress;
            prof.Phone = profile.Phone;
            prof.Email = profile.Email;
            _context.SaveChanges();
        }

        // Create Profile for Applicant
        public void CreateProfile(Profile profile)
        {
            _context.Profile.Add(profile);
            _context.SaveChanges();
        }
    }
}
