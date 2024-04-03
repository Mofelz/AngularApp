using AngularApp2.Server.Models;

namespace AngularApp2.Server.Interfaces
{
    public interface IFio
    {
        Fio GetById(int id);
        bool Add(Fio company);
        bool Update(Fio company);
        bool Delete(int id);

    }
}
