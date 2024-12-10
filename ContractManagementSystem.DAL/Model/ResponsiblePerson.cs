
namespace ContractManagementSystem.DAL.Model
{
    public class ResponsiblePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        // Many-to-One relationship with Addendum
        public int AddendumId { get; set; }
        public Addendum Addendum { get; set; }
    }

}
