using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp2.Server.Controllers
{
    public class CompanyController : Controller
    {
        ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpGet]
        [Route("api/company/getall")]
        public IEnumerable<Company> GetAll()
        {
            return _company.GetAll();
        }
        [HttpGet]
        [Route("api/company/add")]
        public bool AddCompany(Company company)
        {

            return _company.Add(company);
        }
    }
}
