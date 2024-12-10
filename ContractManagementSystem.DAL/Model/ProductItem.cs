

namespace ContractManagementSystem.DAL.Model
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Many-to-One relationship with Addendum
        public int AddendumId { get; set; }
        public Addendum Addendum { get; set; }
    }

}
