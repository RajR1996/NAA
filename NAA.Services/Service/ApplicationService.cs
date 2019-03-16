using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.IDAO;
using NAA.Data.DAO;
using NAA.Data.BEANS;

namespace NAA.Services.Service
{
    public class ApplicationService : NAA.Services.IService.IApplicationService
    {
        private IApplicationDAO _applicationDAO;
        public ApplicationService()
        {
            _applicationDAO = new ApplicationDAO();
        }

        //public IList<Application> GetMyApplications(int ApplicantId)
        //{
        //    return _applicationDAO.GetMyApplications(ApplicantId);
        //}

        public IList<GetMyApplicationsBEAN> GetMyApplications(int ApplicantId)
        {
            return _applicationDAO.GetMyApplications(ApplicantId);
        }

        public Application GetOneApplication(int ApplicationId)
        {
            return _applicationDAO.GetOneApplication(ApplicationId);
        }

        // Gets details of 1 application for universities for the webservice
        public StudentApplicationBEAN GetOneUniApplication(int ApplicationId)
        {
            return _applicationDAO.GetOneUniApplication(ApplicationId);
        }

        public void EditApplication(Application application)
        {
            _applicationDAO.EditApplication(application);
        }

        public void CreateApplication(Application application)
        {
            _applicationDAO.CreateApplication(application);
        }

        public void DeleteApplication(Application application)
        {
            _applicationDAO.DeleteApplication(application);
        }

        //public IList<Application> GetUniversityApplications(int UniversityId)
        //{
        //    return _applicationDAO.GetUniversityApplications(UniversityId);
        //}

        public IList<UniversityApplicationsBEAN> GetUniversityApplications(int UniversityId)
        {
            return _applicationDAO.GetUniversityApplications(UniversityId);
        }

        public void UpdateUniversityOffer(int ApplicationId, string UniversityOffer)
        {
            _applicationDAO.UpdateUniversityOffer(ApplicationId, UniversityOffer);
        }
    }
}
