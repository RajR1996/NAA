using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.BEANS;

namespace NAA.Services.IService
{
    public interface IApplicationService
    {
        //IList<Application> GetMyApplications(int ApplicantId);

        IList<GetMyApplicationsBEAN> GetMyApplications(int ApplicantId);

        Application GetOneApplication(int ApplicationId);

        // Gets details of 1 application for universities for the webservice
        StudentApplicationBEAN GetOneUniApplication(int ApplicationId);

        void EditApplication(Application application);

        void CreateApplication(Application application);

        void DeleteApplication(Application application);

        //IList<Application> GetUniversityApplications(int UniversityId);

        IList<UniversityApplicationsBEAN> GetUniversityApplications(int UniversityId);

        void UpdateUniversityOffer(int ApplicationId, string UniversityOffer);

    }
}
