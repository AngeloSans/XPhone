using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities;

namespace XPhone.Application.Command
{
    public class DeleteReturnCommand
    {
        public Guid Id { get; set; }    
    }
    public class CreateReturnCommand
    {
        public Guid Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Condition { get; set; }
        public Guid RentId { get; set; }
    }
}
