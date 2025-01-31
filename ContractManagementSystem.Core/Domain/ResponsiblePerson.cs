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
        // Relacja do Account(jedna ResponsiblePerson -> wiele Account)
        public List<Account> Accounts { get; set; } = new();

        public Guid? AnnexId { get; set; }
        public Annex Annexes { get; set; }
    }

}
