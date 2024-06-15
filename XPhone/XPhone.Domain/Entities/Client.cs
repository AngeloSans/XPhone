using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool Fine { get; set; }

        [Required]
        public double FineAmount { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}