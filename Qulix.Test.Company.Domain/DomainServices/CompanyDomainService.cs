using Qulix.Test.Company.Domain.DomainServices.Interfaces;
using Qulix.Test.Company.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qulix.Test.Company.Domain.DomainServices
{
   public class CompanyDomainService : ICompanyDomainService
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyDomainService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public List<Models.Company> GetAll()
        {
            return companyRepository.GetAll();
        }

        public Models.Company Get(int id)
        {
            return companyRepository.Get(id);
        }

        public void Edit(Models.Company company)
        {
            companyRepository.Edit(company);
        }

        public void Add(Models.Company company)
        {
            companyRepository.Add(company);
        }

        public void Delete(int id)
        {
            companyRepository.Delete(id);
        }
    }
}
