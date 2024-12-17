//using ContractManagementSystem.DAL.Model;

using ContractManagementSystem.Core.Domain;

namespace ContractManagementSystem.DAL.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Contract> Contracts { get; }
        IRepository<Addendum> Addendums { get; }
        IRepository<ProductItem> ProductItems { get; }
        IRepository<ResponsiblePerson> ResponsiblePersons { get; }
        IRepository<Category> Categories { get; }

        int SaveChanges(); // Zapisuje wszystkie zmiany do bazy danych
    }
}
