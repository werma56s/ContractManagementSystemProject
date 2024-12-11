

namespace ContractManagementSystem.DAL.Model
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }

        // One-to-Many relationship with Addendums
        public ICollection<Addendum> Addendums { get; set; }

        // One-to-One relationship with Category
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
