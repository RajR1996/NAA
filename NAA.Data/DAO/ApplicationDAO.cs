using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;
using NAA.Data.BEANS;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        private NAAEntities _context;
        public ApplicationDAO()
        {
            _context = new NAAEntities();
        }

        public IList<GetMyApplicationsBEAN> GetMyApplications(int ApplicantId)
        {
            IQueryable<GetMyApplicationsBEAN> _applicationBEANS = from apps in _context.Application
                                                            from unis in _context.University
                                                            where ApplicantId == apps.ApplicantId
                                                            where apps.UniversityId == unis.UniversityId
                                                            select new GetMyApplicationsBEAN
                                                            {
                                                                ApplicationId = apps.ApplicationId,
                                                                ApplicantId = ApplicantId,
                                                                CourseName = apps.CourseName,
                                                                UniversityName = unis.UniversityName,
                                                                UniversityOffer = apps.UniversityOffer,
                                                                Firm = apps.Firm
                                                            };
            return _applicationBEANS.ToList<GetMyApplicationsBEAN>();
                                                            

        }

        // Old GetMyApplications which showed UniversityId instead of UniversityName
        //public IList<Application> GetMyApplications(int ApplicantId)
        //{
        //    IQueryable<Application> _applications;
        //    _applications = from Application
        //                    in _context.Application
        //                    where Application.ApplicantId == ApplicantId
        //                    select Application;
        //    return _applications.ToList<Application>();
        //}



        public Application GetOneApplication(int ApplicationId)
        {
            IQueryable<Application> _application;
            _application = from Application
                           in _context.Application
                           where Application.ApplicationId == ApplicationId
                           select Application;
            return _application.First();
        }

        // Gets details of 1 application for universities for the webservice
        public StudentApplicationBEAN GetOneUniApplication(int ApplicationId)
        {
            IQueryable<StudentApplicationBEAN> _studappBEANS = from apps in _context.Application
                                                               from profs in _context.Profile
                                                               from unis in _context.University
                                                               where apps.ApplicationId == ApplicationId
                                                               where apps.UniversityId == unis.UniversityId
                                                               where apps.ApplicationId == profs.ApplicantId
                                                               select new StudentApplicationBEAN
                                                               {
                                                                   ApplicantName = profs.ApplicantName,
                                                                   ApplicantAddress = profs.ApplicantAddress,
                                                                   Phone = profs.Phone,
                                                                   Email = profs.Email,
                                                                   UniversityName = unis.UniversityName,
                                                                   CourseName = apps.CourseName,
                                                                   PersonalStatement = apps.PersonalStatement,
                                                                   TeachReference = apps.TeachReference,
                                                                   TeacherContactDetails = apps.TeacherContactDetails,
                                                                   UniversityOffer = apps.UniversityOffer,
                                                                   Firm = apps.Firm
                                                               };
            return _studappBEANS.FirstOrDefault<StudentApplicationBEAN>();
        }

        public void EditApplication(Application application)
        {
            Application app = GetOneApplication(application.ApplicationId);
            var Count = 0;

            IQueryable<Application> _firms;
                _firms = from Application
                         in _context.Application
                         where Application.ApplicantId == app.ApplicantId
                         where Application.Firm == true
                         select Application;
            Count = _firms.Count();
            // If there isn't a firm application already for this user
            if (Count < 1)
            {
                // Make chosen application firm
                app.Firm = application.Firm;
                _context.SaveChanges();
            }
            // else if there is already a firm for the user 
            else
            {
                // If user is trying to make firm application a non firm one then allow and save changes
                if (app.Firm == true)
                {
                    app.Firm = application.Firm;
                    _context.SaveChanges();
                }
                // else do nothing
                else
                {
                    // 
                }

            }
        }

        public void CreateApplication(Application application)
        {
            var Count = 0;
            IQueryable<Application> _duplicates;
            _duplicates = from Application
                          in _context.Application
                          where Application.ApplicantId == application.ApplicantId
                          where Application.CourseName == application.CourseName
                          select Application;
            Count = _duplicates.Count();

            // Only insert the data into the table if the applicant hasn't already applied for this course
            // If you do try to apply for a course you've already applied for it just shows the details of the first application for that applicant
            if (Count == 0)
            {
                application.UniversityOffer = "P";
                application.Firm = false;
                _context.Application.Add(application);
                _context.SaveChanges();
            }
        }

        public void DeleteApplication(Application application)
        {
            // If Applicant has a pending application they are allowed to delete their application.
            var UniOffer = application.UniversityOffer;
            if (UniOffer == "P")
            {
                _context.Application.Remove(application);
                _context.SaveChanges();
            }
        }

        //public IList<Application> GetUniversityApplications(int UniversityId)
        //{
        //    IQueryable<Application> _allapplications;
        //    _allapplications = from Application
        //                    in _context.Application
        //                    where Application.UniversityId == UniversityId 
        //                    select Application;
        //    return _allapplications.ToList<Application>();
        //}

        public IList<UniversityApplicationsBEAN> GetUniversityApplications(int UniversityId)
        {
            IQueryable<UniversityApplicationsBEAN> _uniappsBEANS = from unis in _context.University
                                                                   from profs in _context.Profile
                                                                   from apps in _context.Application
                                                                   where apps.UniversityId == UniversityId
                                                                   where apps.UniversityId == unis.UniversityId
                                                                   where profs.ApplicantId == apps.ApplicantId
                                                                   select new UniversityApplicationsBEAN
                                                                   {
                                                                       ApplicantName = profs.ApplicantName,
                                                                       ApplicantAddress = profs.ApplicantAddress,
                                                                       Phone = profs.Phone,
                                                                       Email = profs.Email,
                                                                       UniversityName = unis.UniversityName,
                                                                       CourseName = apps.CourseName,
                                                                       PersonalStatement = apps.PersonalStatement,
                                                                       TeachReference = apps.TeachReference,
                                                                       TeacherContactDetails = apps.TeacherContactDetails,
                                                                       UniversityOffer = apps.UniversityOffer,
                                                                       Firm = apps.Firm
                                                                   };
            return _uniappsBEANS.ToList<UniversityApplicationsBEAN>();
        }
        



        public void UpdateUniversityOffer(int ApplicationId, string UniversityOffer)
        {
            Application app = GetOneApplication(ApplicationId);

            // Only update the database if application is Pending in the database
            if (app.UniversityOffer == "P")
            {
                app.UniversityOffer = UniversityOffer;
                _context.SaveChanges();
            }
        }
    }
}
