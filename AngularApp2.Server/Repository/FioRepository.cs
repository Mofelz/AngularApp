using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Repository
{
    public class FioRepository : IFio
    {
        private DazaBannixContext _context;

        public FioRepository(DazaBannixContext context) 
        { 
            _context = context;
        }
        public IEnumerable<Fio> GetAll() 
        {
            return _context.Fios;
        }
    }
}
