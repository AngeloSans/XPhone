using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities.DTO
{
    public class RentDTO
    {

        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double RentAmount { get; set; }

        public bool Devolution { get; set; }

        public String Client { get; set; }

        public String SmartPhone { get; set; }
        public virtual SmartPhone SmartPhone { get; set; }

        public String Return { get; set; }
    }
}
