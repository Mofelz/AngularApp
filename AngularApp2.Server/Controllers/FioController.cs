using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;
using Microsoft.AspNetCore.Mvc;


namespace AngularApp2.Server.Controllers
{
    public class FioController : Controller
    {
        IFio _fio;

        public FioController(IFio fio) 
        {
            _fio = fio;
        }

        [HttpGet]
        [Route("api/fio/getall")]
        public IEnumerable<Fio> GetAll() 
        {
            return _fio.GetAll();
        }
    }
}
