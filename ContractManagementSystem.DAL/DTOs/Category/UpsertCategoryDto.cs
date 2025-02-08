using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.DTOs.Category
{
    public class UpsertCategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
