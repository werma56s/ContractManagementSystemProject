using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Contract;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface IContractService
    {
        List<ContractDto> GetAllContracts();
        ContractDto GetContractById(Guid id);
        void AddContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(Guid id);
    }
}
