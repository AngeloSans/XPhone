using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Application.Command
{
    public class UpdateSmartPhoneCommand
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public bool Avaiable { get; set; }
        public string OperationalSystem { get; set; }
        public int Memory { get; set; }
        public double Core { get; set; }
    }
    public class DeleteSmartPhoneCommand
    {
        public Guid Id { get; set; }
    }
    public class CreateSmartPhoneCommand
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public bool Avaiable { get; set; }
        public string OperationalSystem { get; set; }
        public int Memory { get; set; }
        public double Core { get; set; }
    }
}
