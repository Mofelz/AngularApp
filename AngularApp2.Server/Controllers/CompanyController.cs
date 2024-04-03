using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Models;
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
        [Route("api/company/getbyid/{id}")]
        public Company GetByIdCompany([FromRoute] int id)
        {
            return _company.GetById(id);
        }
        [HttpPost]
        [Route("api/company/add")]
        public Company AddCompany([FromBody] Company company)
        {
            return _company.Add(company);
        }
        [HttpPut]
        [Route("api/company/update")]
        public string UpdateCompany([FromBody] Company company)
        {
            return _company.Update(company);
        }
        [HttpDelete]
        [Route("api/company/delete/{id}")]
        public bool DeleteCompany([FromRoute] int id)
        {
            return _company.Delete(id);
        }

    }
}
