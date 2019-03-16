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
    public class ProfileService : NAA.Services.IService.IProfileService
    {
        private IProfileDAO _profileDAO;
        public ProfileService()
        {
            _profileDAO = new ProfileDAO();
        }

        public Profile GetProfile(int ApplicantId)
        {
            return _profileDAO.GetProfile(ApplicantId);
        }

        public void EditProfile(Profile profile)
        {
            _profileDAO.EditProfile(profile);
        }

        public void CreateProfile(Profile profile)
        {
            _profileDAO.CreateProfile(profile);
        }

        public int GetApplicantId(string UserId)
        {
            return _profileDAO.GetApplicantId(UserId);
        }
        

    }
}
