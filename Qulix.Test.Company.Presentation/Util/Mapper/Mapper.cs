using Qulix.Test.Company.Domain.Models;
using Qulix.Test.Company.Presentation.Models;

namespace Qulix.Test.Company.Presentation.Util.Mapper
{
    public static class Mapper
    {
        public static EmployeeView EmployeeToEmployeeView(Employee employee)
        {
            return new EmployeeView
            {
                Company = employee.Company,
                EmploymentDate = employee.EmploymentDate,
                FirstName = employee.FirstName,
                Id = employee.Id,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Position = employee.Position,
            };
        }

        public static Employee EmployeeViewToEmployee(EmployeeView employee)
        {
            return new Employee
            {
                Company = employee.Company,
                EmploymentDate = employee.EmploymentDate,
                FirstName = employee.FirstName,
                Id = employee.Id,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Position = employee.Position,
            };
        }
    }
}
