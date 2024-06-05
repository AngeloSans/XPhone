﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities
{
    class Client
    {
        [Key]
        private Guid _Id { get; set; }

        [Required]
        [StringLength(100)]
        private string _Name { get; set; }

        [Required]
        [EmailAddress]
        private string _Email { get; set; }

        [Required]
        private bool _Fine { get; set; }

        [Required]
        private double _FineAmount { get; set; }

    }
}
