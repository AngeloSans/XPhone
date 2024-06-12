using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities.DTO
{
    class ReturnDTO
    {
        public Guid Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Condition { get; set; }
       
        public String Rent {  get; set; }
    }
}
