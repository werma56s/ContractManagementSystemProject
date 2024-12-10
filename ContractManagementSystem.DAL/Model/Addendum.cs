using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.Model
{
    public class Addendum
    {
        public int Id { get; set; }
        public string AddendumNumber { get; set; }
        public DateTime SignedDate { get; set; }

        // Many-to-One relationship with Contract
        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        // One-to-Many relationship with Product Items
        public ICollection<ProductItem> ProductItems { get; set; }

        // One-to-Many relationship with Responsible Persons
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }
    }

}
