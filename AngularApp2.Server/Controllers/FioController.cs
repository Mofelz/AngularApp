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
        [HttpGet]
        [Route("api/fio/getbyid/{id}")]
        public Fio GetByIdFio([FromRoute] int id)
        {
            return _fio.GetById(id);
        }
        [HttpPost]
        [Route("api/fio/add")]
        public bool AddFio(Fio fio)
        {
            return _fio.Add(fio);
        }
        [HttpPut]
        [Route("api/fio/update")]
        public bool UpdateFio(Fio fio)
        {
            return _fio.Update(fio);
        }
        [HttpDelete]
        [Route("api/fio/delete")]
        public bool DeleteFio(int id)
        {
            return _fio.Delete(id);
        }
    }
}
