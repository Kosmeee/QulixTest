using Microsoft.AspNetCore.Mvc;
using Qulix.Test.Company.Domain.DomainServices.Interfaces;

namespace Qulix.Test.Company.Presentation.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyDomainService companyDomainService;

        public CompanyController(ICompanyDomainService companyDomainService)
        {
            this.companyDomainService = companyDomainService;
        }

        public IActionResult Index()
        {
            return View(companyDomainService.GetAll());
        }

        public IActionResult Edit(int id)
        {
            return View(companyDomainService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Domain.Models.Company company)
        {
            if (ModelState.IsValid)
            {
                companyDomainService.Edit(company);
                return RedirectToAction("Index");
            }

            return View("Edit", company);
        }

        public IActionResult Add()
        {
            return View("Edit", new Domain.Models.Company());
        }

        [HttpPost]
        public IActionResult Add(Domain.Models.Company company)
        {
            if (ModelState.IsValid)
            {
                companyDomainService.Add(company);
                return RedirectToAction("Index");
            }

            return View("Edit", company);
        }

        public IActionResult Delete(int id)
        {
            companyDomainService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
