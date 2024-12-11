
namespace ContractManagementSystem.DAL.Model
{
    public class ResponsiblePerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        // Many-to-One relationship with Addendum
        public Guid AddendumId { get; set; }
        public Addendum Addendum { get; set; }
    }

}
