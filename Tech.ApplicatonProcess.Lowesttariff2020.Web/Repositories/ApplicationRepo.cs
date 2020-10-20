using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Data;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Tech.ApplicatonProcess.Lowesttariff2020.Web.Repositories
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly ApplicationDbContext _context;
        public ApplicationRepo( ApplicationDbContext context)
        {
            _context = context;
        }

        public Application AddApplication(Application obj)
        {
  
            _context.Applications.Add(obj);
            _context.SaveChanges();
            return obj;
        }

       

        public Application DeleteApplicationByID(int ID)
        {

             Application application=this.GetApplicationByID(ID);
            this._context.Applications.Remove(application);
            this._context.SaveChanges();

            return application;
             
            
            
        }

        public IEnumerable<Application> GetAllApplications()
        {
             var list=_context.Applications.ToList();
            return list;
        }

        public Application GetApplicationByID(int ID)
        {
            return _context.Applications.First<Application>(c => c.ID == ID);
        }

        public Application UpdateApplicationID(int ID,Application updateApplication)

        {
            Application currentApplication = this.GetApplicationByID(ID);
            currentApplication.Name = updateApplication.Name;
            currentApplication.FamilyName = updateApplication.FamilyName;
            currentApplication.CountryOfOrigin = updateApplication.CountryOfOrigin;
            currentApplication.EmailAddress = updateApplication.EmailAddress;
            currentApplication.Address = updateApplication.Address;
            currentApplication.Age = updateApplication.Age;
            currentApplication.Hired = updateApplication.Hired;
            this._context.Entry(currentApplication).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
            return currentApplication;
        }
    }
}
