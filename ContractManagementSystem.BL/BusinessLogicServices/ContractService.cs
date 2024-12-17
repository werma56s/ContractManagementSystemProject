using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.Core.Domain;

//using ContractManagementSystem.DAL.Model;
using ContractManagementSystem.DAL.Services.Interfaces;

namespace ContractManagementSystem.BL.BusinessLogicServices
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContractService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            return _unitOfWork.Contracts.GetAll().ToList();
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
