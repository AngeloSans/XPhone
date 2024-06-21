using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Application.Command
{
    public class CreateRentCommand
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentAmount { get; set; }
        public bool Devolution { get; set; }
    }
    public class UpdateRentCommand
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentAmount { get; set;}
        public bool Devolution { get; set; }

    }
    public class DeleteRentCommand
    {
        public Guid Id { get; set; }
    }
}
