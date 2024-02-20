using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Interfaces
{
    public interface ICompany
    {
        IEnumerable<Company> GetAll();
        bool Add(Company company);
    }
}
