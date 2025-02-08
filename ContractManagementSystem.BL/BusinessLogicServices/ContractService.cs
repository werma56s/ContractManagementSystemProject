using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.Assemblers;
using ContractManagementSystem.DAL.DTOs.Contract;
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
            return _unitOfWork.Contracts.GetAll().Where(x=>x.IsDeleted==false).Select(_contractAssemblers.ExpGetContractDto).ToList();
        }

        public ContractDto GetContractById(Guid id)
        {   
            return _unitOfWork.Contracts.GetAll().Where(x => x.IsDeleted == false).Where(c => c.Id == id)
                              .Select(_contractAssemblers.ExpGetContractDto)
                              .First();
        }

        public void AddContract(UpsertContractDto contractDto)
        {
                // Mapowanie ContractDto -> Contract
                var contract = _contractAssemblers.MapToContract(contractDto);
                // Dodanie nowego kontraktu do bazy danych
                _unitOfWork.Contracts.Add(contract);
                // Zapisanie zmian
                _unitOfWork.SaveChanges();
        }

        public void UpdateContract(Guid Id, UpsertContractDto contractDto)
        {
            if (_unitOfWork.Contracts.GetById(Id) == null || _unitOfWork.Contracts.GetById(Id).IsDeleted)
                return; // Jeśli contract nie istnieje lub jest usunięty, kończymy metodę.
            var contract = _contractAssemblers.MapToContract(contractDto,Id);
            _unitOfWork.Contracts.Update(contract);
            _unitOfWork.SaveChanges();
        }

        public void DeleteContract(Guid id)
        {
            var contract = _unitOfWork.Contracts.GetAll().Where(x => x.IsDeleted == false).Where(c => c.Id == id).First();
            if (contract != null)
            {
                // Ustawiamy flagę IsDeleted na true
                contract.IsDeleted = true;
                // Zapisujemy zmiany w bazie danych
                _unitOfWork.SaveChanges();
            }
        }
    }
}
