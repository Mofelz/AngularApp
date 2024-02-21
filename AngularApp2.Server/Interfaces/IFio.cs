using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Interfaces
{
    public interface IFio
    {
        IEnumerable<Fio> GetAll();
        Fio GetById(int id);
        bool Add(Fio company);
        bool Update(Fio company);
        bool Delete(int id);
        
    }
}
