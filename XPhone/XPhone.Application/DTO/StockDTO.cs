using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;

namespace XPhone.Domain.Entities.DTO
{
    public class StockDTO
    {
        public Guid Id { get; set; }

        public string stockName { get; set; }

        public double amount { get; set; }

        public List<CreateSmartPhoneCommand> Phones {  get; set; }

        

    }
}
