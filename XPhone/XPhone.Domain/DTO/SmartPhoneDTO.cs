using System;

namespace XPhone.Domain.Entities.DTO
{
    public class SmartPhoneDTO
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public bool Avaiable { get; set; } 
        public string OperationalSystem { get; set; }
        public int Memory { get; set; }
        public double Core { get; set; }

        public StockDTO Stock { get; set; }
        public Guid StockId { get; set; }

    }
}
