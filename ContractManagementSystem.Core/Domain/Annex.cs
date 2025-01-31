using ContractManagementSystem.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace ContractManagementSystem.Core.Domain
{
    public class Annex : IDomainEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        // ----------------------------------------------
        [Required]
        public string AnnexNumber { get; set; } = string.Empty;

        [Required]
        public DateTime SignedDate { get; set; }
        
        public Guid? ContractId { get; set; }
        public Contract Contract { get; set; }

        public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; } = new List<ResponsiblePerson>();
    }

}
