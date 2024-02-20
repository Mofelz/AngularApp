using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Interfaces
{
    public interface ICompany
    {
        IEnumerable<Company> GetAll();
        bool Add(Company company);
        bool Update(Company company);
        bool Delete(int id);
        Company GetById(int id);
    }
}
