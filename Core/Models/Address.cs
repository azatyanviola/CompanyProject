using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Address : BaseEntity
    {
        

      
        public string? Address1 { get; set; }
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        
    }
}
