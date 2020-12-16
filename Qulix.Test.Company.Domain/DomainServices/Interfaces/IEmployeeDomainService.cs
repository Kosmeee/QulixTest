using Qulix.Test.Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qulix.Test.Company.Domain.DomainServices.Interfaces
{
   public interface IEmployeeDomainService
    {
        List<Employee> GetAll();

        Employee Get(int id);

        void Edit(Employee employee);

        void Add(Employee employee);

        void Delete(int id);
    }
}
