﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem.DAL.DTOs.Contract
{
    public class UpsertContractDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }
        //public Guid? CategoryId { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
    }

}
