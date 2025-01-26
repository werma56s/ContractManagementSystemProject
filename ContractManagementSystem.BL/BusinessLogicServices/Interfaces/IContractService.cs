using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Contract;

namespace ContractManagementSystem.BL.BusinessLogicServices.Interfaces
{
    public interface IContractService
    {
        List<ContractDto> GetAllContracts();
        ContractDto GetContractById(Guid id);
        void AddContract(UpsertContractDto contract);
        void UpdateContract(Guid Id, UpsertContractDto contract);
        void DeleteContract(Guid id);
    }
}
