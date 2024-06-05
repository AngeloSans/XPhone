using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Domain.Entities.DTO
{
    class SmartPhoneDTO
    {
        private Guid _Ìd {  get; set; }

        private string _Model {  get; set; }

        private double _Price { get; set; }

        private bool _Avaiable {  get; set; }

        private string _OperationalSystem { get; set; }

        private int _Memory {  get; set; }

        private double _code { get; set; }
    }
}
