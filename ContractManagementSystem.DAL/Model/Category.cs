
namespace ContractManagementSystem.DAL.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // One-to-One relationship with Contract
        public Contract Contract { get; set; }
    }

}
