using ContractManagementSystem.Core.Domain;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface IAddendumService
    {
        IEnumerable<Addendum> GetAllAddendums();
        Addendum GetAddendumById(Guid id);
        void AddAddendum(Addendum addendum);
        void UpdateAddendum(Addendum addendum);
        void DeleteAddendum(Guid id);
    }
}
