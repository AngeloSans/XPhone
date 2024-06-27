﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Domain.Entities.DTO;

namespace XPhone.Application.Command
{
    public class CreateStockCommand
    {
        public string stockName { get; set; }

        
    }
    public class UpdateStockCommmand
    {   
        public Guid id { get; set; }
        public string stockName { get; set; }
    }
    public class DeleteStockCommand 
    { 
        public Guid id { get; set; }
    }


}
