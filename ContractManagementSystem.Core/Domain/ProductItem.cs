using ContractManagementSystem.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ContractManagementSystem.Core.Domain
{
    public class ProductItem : IDomainEntity
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
        [MaxLength(255)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Guid? AddendumId { get; set; }
        public Addendum Addendum { get; set; }
    }

}
