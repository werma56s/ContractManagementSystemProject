using System;
using System.Linq.Expressions;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Contract;

namespace ContractManagementSystem.DAL.Assemblers
{
    public class ContractAssemblers
    {
        // Mapowanie Contract -> ContractDto
        public Expression<Func<Contract, ContractDto>> ExpGetContractDto { get; } = domain => new ContractDto()
        {
            Id = domain.Id,
            DateCreated = domain.DateCreated,
            DateModified = domain.DateModified,
            IsDeleted = domain.IsDeleted,
            CreatedBy = domain.CreatedBy,
            ModifiedBy = domain.ModifiedBy,
            Name = domain.Name,
            StartDate = domain.StartDate,
            EndDate = domain.EndDate,
            Value = domain.Value,
            Category = new DTOs.CategoryDTO
            {
                ID =  domain.Category.Id,
                Name = domain.Category.Name,
                Description = domain.Category.Description,
            }
        };
        // Mapowanie ContractDto -> Contract (tu zwykła metoda)
        public Contract MapToContract( UpsertContractDto dto, Guid? Id = null)
        {
            var contract = new Contract
            {
                Id = Id ?? Guid.NewGuid(),  // Jeśli Id jest null, przypisujemy nowy GUID
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Value = dto.Value,
                CategoryId = dto.CategoryId,
            };

            // Warunkowe przypisanie DateCreated lub DateModified
            if (Id == null)
            {
                contract.DateCreated = DateTime.UtcNow;
            }
            else
            {
                contract.DateModified = DateTime.UtcNow;
            }

            return contract;
        }
    }
}
