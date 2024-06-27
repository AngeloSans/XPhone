using System;

namespace XPhone.Domain.Entities.DTO
{
    public class RentDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double RentAmount { get; set; }
        public bool Devolution { get; set; }
        public Guid ClientId { get; set; }
        public ClientDTO Client { get; set; }

        public Guid SmartPhoneId { get; set; }

        public SmartPhoneDTO SmartPhone { get; set; }

        
    }
}
