using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Data.IDAO
{
    public interface IProfileDAO
    {
        Profile GetProfile(int ApplicantId);

        void EditProfile(Profile profile);

        void CreateProfile(Profile profile);

        int GetApplicantId(string UserId);
    }
}
