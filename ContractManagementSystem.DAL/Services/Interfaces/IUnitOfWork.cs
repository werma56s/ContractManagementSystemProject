//using ContractManagementSystem.DAL.Model;

using ContractManagementSystem.Core.Domain;

namespace ContractManagementSystem.DAL.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Contract> Contracts { get; }
        IRepository<Annex> Annexes { get; }
        IRepository<ProductItem> ProductItems { get; }
        IRepository<ResponsiblePerson> ResponsiblePersons { get; }
        IRepository<Category> Categories { get; }
        IRepository<Account> Accounts{ get; }

        int SaveChanges(); // Zapisuje wszystkie zmiany do bazy danych
    }
}
