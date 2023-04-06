using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class CompanyPosition : BaseEntity
    {
        public int? CompanyId { get; set; }
        public int? PositionId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Position? Position { get; set; }
    }
}
