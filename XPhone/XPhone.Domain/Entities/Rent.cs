using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities
{
    public class Rent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public double RentAmount { get; set; }

        [Required]
        public bool Devolution { get; set; }

        public Guid ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public Guid SmartPhoneId { get; set; }
        [ForeignKey("SmartPhoneId")]
        public virtual SmartPhone SmartPhone { get; set; }

        public virtual Return Return { get; set; }

       
    }
}
