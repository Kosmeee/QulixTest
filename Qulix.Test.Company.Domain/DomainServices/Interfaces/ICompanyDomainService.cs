using System;
using System.Collections.Generic;
using System.Text;

namespace Qulix.Test.Company.Domain.DomainServices.Interfaces
{
   public interface ICompanyDomainService
    {
        List<Models.Company> GetAll();

        Models.Company Get(int id);

        void Edit(Models.Company company);

        void Add(Models.Company company);

        void Delete(int id); // Delete Company WITH ALL CONNECTED EMPLOYEES
    }
}
