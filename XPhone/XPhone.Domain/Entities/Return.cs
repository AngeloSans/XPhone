using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities
{
    class Return
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public bool Condition { get; set; }
    }
}
