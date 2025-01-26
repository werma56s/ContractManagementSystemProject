using ContractManagementSystem.Core.Domain;
using ContractManagementSystem.Core.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace ContractManagementSystem.Core.Domain
{
    public class Category : IDomainEntity
    {
        [Required]
        public Guid Id { get ; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        //// ----------------------------------------------
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1023)]
        public string? Description { get; set; }

        public ICollection<Contract> Contracts { get; set; }

    }
}