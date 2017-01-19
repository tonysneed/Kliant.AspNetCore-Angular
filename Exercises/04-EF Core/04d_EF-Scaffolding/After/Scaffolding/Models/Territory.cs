﻿using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }

        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
    }
}
