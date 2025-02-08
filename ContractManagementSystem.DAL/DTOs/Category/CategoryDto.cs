using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.DTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        //
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        //
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
