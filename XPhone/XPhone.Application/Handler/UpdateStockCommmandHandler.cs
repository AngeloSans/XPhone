﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Command;
using XPhone.Infra.Repository;

namespace XPhone.Application.Handler
{
    public class UpdateStockCommmandHandler : ICommandHandler<UpdateStockCommmand>
    {
        private readonly StockRepository _stockRepository;

        public UpdateStockCommmandHandler(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Guid> HandlerAsync(UpdateStockCommmand command)
        {
            var stock = await _stockRepository.GetStockById(command.id);
            if (stock != null) 
            {
                stock.stockName = command.stockName;
                
            }
            else
            {
                throw new KeyNotFoundException("Stock not found");
            }
            return command.id;
        }
    }
}
