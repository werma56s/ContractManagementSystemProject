using ContractManagementSystem.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ContractManagementSystem.Core.Domain
{
    public class ResponsiblePerson : IDomainEntity
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
        public string Position { get; set; } = string.Empty;

        public Guid AddendumId { get; set; }
        public Addendum Addendum { get; set; }
    }

}
