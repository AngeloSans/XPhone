using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities.DTO
{
    class ClientDTO
    {
        private Guid _Id {  get; set; }
        private string _Name { get; set; }
        private string _Email { get; set; }
        private bool _Fine { get; set; }
        private double _FineAmount { get; set; }
    }
}
