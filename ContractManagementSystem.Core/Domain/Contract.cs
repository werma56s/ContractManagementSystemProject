using ContractManagementSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.Core.Domain
{
    public class Contract : IDomainEntity
    {
        // Wspólne właściwości z IDomainEntity
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
        // Specyficzne właściwości kontraktu
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public decimal Value { get; set; }

        // ----------------------------------------------
        // Relacje
        // Relacja jeden-do-wielu z Addendum
        public ICollection<Addendum> Addendums { get; set; } = new List<Addendum>();

        // Relacja jeden-do-jeden z Category
        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }

}
