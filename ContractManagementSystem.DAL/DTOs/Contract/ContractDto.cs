using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.DTOs.Contract
{
    public class ContractDto : IDomainEntity
    {
        public Guid Id { get; set; }
        //
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        //
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }

        public CategoryDTO Category { get; set; }
        //    public Guid CategoryId { get; set; }
        //    public string CategoryName { get; set; } // Opcjonalnie: nazwa kategorii
    }

}
