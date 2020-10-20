using System;
using System.Collections.Generic;
using Tech.ApplicatonProcess.Lowesttariff2020.Web.Model;

namespace Tech.ApplicatonProcess.Lowesttariff2020.Web.Repositories
{
    public interface IApplicationRepo
    {
        IEnumerable<Application> GetAllApplications();
        Application  AddApplication(Application obj);
        Application GetApplicationByID(int ID);
        Application UpdateApplicationID(int ID,Application toupdate);
        Application DeleteApplicationByID(int ID);

    }
}
