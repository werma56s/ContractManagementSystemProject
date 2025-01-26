﻿using System.Linq.Expressions;
using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.DAL.DTOs.Contract;

namespace ContractManagementSystem.DAL.Assemblers
{
    public class ContractAssemblers
    {
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
    }
}
