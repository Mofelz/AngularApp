using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Interfaces
{
    public interface IFio
    {
        IEnumerable<Fio> GetAll();
    }
}
