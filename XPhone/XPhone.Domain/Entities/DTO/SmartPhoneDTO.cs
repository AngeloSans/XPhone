using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities.DTO
{
    class SmartPhoneDTO
    {

        public Guid Id { get; set; }

        public string Model { get; set; }


        public double Price { get; set; }

        public bool Avaiable { get; set; }


        public string OperationalSystem { get; set; }

        public int Memory { get; set; }

        public double Core { get; set; }


    }
}
