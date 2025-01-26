using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.Assemblers;
using ContractManagementSystem.DAL.DTOs.Contract;



//using ContractManagementSystem.DAL.Model;
using ContractManagementSystem.DAL.Services.Interfaces;

namespace ContractManagementSystem.BL.BusinessLogicServices
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ContractAssemblers _contractAssemblers;

        public ContractService(IUnitOfWork unitOfWork, ContractAssemblers contractAssemblers)
        {
            _unitOfWork = unitOfWork;
            _contractAssemblers = contractAssemblers;
        }

        public List<ContractDto> GetAllContracts()
        {
            return _unitOfWork.Contracts.GetAll().Select(_contractAssemblers.ExpGetContractDto).ToList();
        }

        public Contract GetContractById(Guid id)
        {
            return _unitOfWork.Contracts.GetById(id);
        }

        public void AddContract(Contract contract)
        {
            _unitOfWork.Contracts.Add(contract);
            _unitOfWork.SaveChanges();
        }

        public void UpdateContract(Contract contract)
        {
            _unitOfWork.Contracts.Update(contract);
            _unitOfWork.SaveChanges();
        }

        public void DeleteContract(Guid id)
        {
            var contract = _unitOfWork.Contracts.GetById(id);
            if (contract != null)
            {
                _unitOfWork.Contracts.Delete(contract);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
