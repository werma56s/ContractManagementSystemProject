﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }

        // One-to-Many relationship with Addendums
        public ICollection<Addendum> Addendums { get; set; }

        // One-to-One relationship with Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}