using ContractManagementSystem.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using ContractManagementSystem.Core.Enums;

namespace ContractManagementSystem.Core.Domain
{
    public class Account : IDomainEntity
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
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public JobPosition Position { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        //
        // Relacja do ResponsiblePerson (wielu Account -> jedna ResponsiblePerson)
        public Guid? ResponsiblePersonId { get; set; }

        public ResponsiblePerson ResponsiblePerson { get; set; }
    }

}
