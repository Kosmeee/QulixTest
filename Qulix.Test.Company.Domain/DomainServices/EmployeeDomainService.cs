using Qulix.Test.Company.Domain.DomainServices.Interfaces;
using Qulix.Test.Company.Domain.Models;
using Qulix.Test.Company.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qulix.Test.Company.Domain.DomainServices
{
   public class EmployeeDomainService : IEmployeeDomainService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDomainService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Add(Employee employee)
        {
            employeeRepository.Add(employee);
        }

        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

        public void Edit(Employee employee)
        {
            employeeRepository.Edit(employee);
        }

        public Employee Get(int id)
        {
            return employeeRepository.Get(id);
        }

        public List<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }
    }
}
