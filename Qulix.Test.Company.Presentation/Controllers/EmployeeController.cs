using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Qulix.Test.Company.Domain.DomainServices.Interfaces;
using Qulix.Test.Company.Presentation.Models;
using Qulix.Test.Company.Presentation.Util.Mapper;

namespace Qulix.Test.Company.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDomainService employeeDomainService;
        private readonly ICompanyDomainService companyDomainService;

        public EmployeeController(IEmployeeDomainService employeeDomainService, ICompanyDomainService companyDomainService)
        {
            this.employeeDomainService = employeeDomainService;
            this.companyDomainService = companyDomainService;
        }

        public IActionResult Index()
        {
            List<EmployeeView> employees = new List<EmployeeView>();
            var domain = employeeDomainService.GetAll();
            foreach (var a in domain)
            {
                employees.Add(Mapper.EmployeeToEmployeeView(a));
            }

            return View(employees);
        }

        public IActionResult Edit(int id)
        {
            var a = Mapper.EmployeeToEmployeeView(employeeDomainService.Get(id));
            a.SelectCompanies = companyDomainService.GetAll();
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView employee)
        {
            employee.Company.Title = string.Empty;
            employee.Company.OrganisationalForm = string.Empty;
            employee.SelectCompanies = companyDomainService.GetAll();
            if (ModelState.IsValid)
            {
                employeeDomainService.Edit(Mapper.EmployeeViewToEmployee(employee));
                return RedirectToAction("Index");
            }

            return View("Edit", employee);
        }

        public IActionResult Add()
        {
            return View("Edit", new EmployeeView { SelectCompanies = companyDomainService.GetAll(), Company = new Domain.Models.Company { Title = "a", OrganisationalForm = "a" }, Position = new Domain.Models.Position() });
        }

        [HttpPost]
        public IActionResult Add(EmployeeView employee)
        {
            employee.SelectCompanies = companyDomainService.GetAll();
            if (ModelState.IsValid)
            {
                employeeDomainService.Add(Mapper.EmployeeViewToEmployee(employee));
                return RedirectToAction("Index");
            }

            return View("Edit", employee);
        }

        public IActionResult Delete(int id)
        {
            employeeDomainService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
