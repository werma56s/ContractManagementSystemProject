using ContractManagementSystem.Core.Domain;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface IContractService
    {
        IEnumerable<Contract> GetAllContracts();
        Contract GetContractById(Guid id);
        void AddContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(Guid id);
    }
}
