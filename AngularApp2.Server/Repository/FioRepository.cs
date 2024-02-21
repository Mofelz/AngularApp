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

        public Fio GetById(int id)
        {
            return _context.Fios.Find(id);
        }

        public bool Add(Fio fio)
        {
            try
            {
                _context.Fios.Add(fio);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Fio fio)
        {
            try
            {
                Fio currentFio = GetById(fio.Id);
                if (currentFio != null)
                {
                    currentFio.Name = fio.Name;
                    currentFio.Surname = fio.Surname;
                    currentFio.Patronomic = fio.Patronomic;
                    currentFio.Number = fio.Number;

                    _context.Fios.Update(currentFio);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Fio currentFio = GetById(id);
                if (currentFio != null)
                {
                    _context.Remove(currentFio);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
