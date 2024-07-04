using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPhone.Infrastructure;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace XPhone.Tests.Repository
{
    public class StockRepositoryTests
    {
        private Mock<XPhoneDbContext> _mockContext;
        private StockRepository _stockRepository;

        public StockRepositoryTests()
        {
            _mockContext = new Mock<XPhoneDbContext>();
            _stockRepository = new StockRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllStocksAsync_ShouldReturnAllStocks()
        {
            // Arrange
            var testData = new List<Stock>
            {
                new Stock { Id = Guid.NewGuid(), stockName = "Stock A", Amount = 3 },
                new Stock { Id = Guid.NewGuid(), stockName = "Stock B", Amount = 4 }
            };
            var mockDbSet = MockDbSet(testData);
            _mockContext.Setup(c => c.Stocks).Returns(mockDbSet.Object);

            // Act
            var result = await _stockRepository.GetAllStocksAsync();

            // Assert
            Assert.Equal(testData.Count, result.Count());
            foreach (var stock in testData)
            {
                Assert.Contains(result, s => s.Id == stock.Id && s.stockName == stock.stockName && s.Amount == stock.Amount);
            }
        }

        [Fact]
        public async Task GetStockByIdAsync_ValidId_ShouldReturnStock()
        {
            // Arrange
            var id = Guid.NewGuid();
            var testData = new Stock { Id = id, stockName = "Stock A", Amount = 3 };
            var mockDbSet = MockDbSet(new List<Stock> { testData });
            _mockContext.Setup(c => c.Stocks.FindAsync(id)).ReturnsAsync(testData);

            // Act
            var result = await _stockRepository.GetStockById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testData.Id, result.Id);
            Assert.Equal(testData.stockName, result.stockName);
            Assert.Equal(testData.Amount, result.Amount);
        }

        [Fact]
        public async Task GetStockByIdAsync_NonExistingId_ShouldReturnNull()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockContext.Setup(c => c.Stocks.FindAsync(id)).ReturnsAsync((Stock)null);

            // Act
            var result = await _stockRepository.GetStockById(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateStockAsync_ValidStock_ShouldUpdateSuccessfully()
        {
            // Arrange
            var testData = new Stock { Id = Guid.NewGuid(), stockName = "Stock A", Amount = 3 };
            _mockContext.Setup(c => c.Stocks.Update(testData));

            // Act
            await _stockRepository.UpdateStockAsync(testData);

            // Assert
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task DeleteStockAsync_ValidId_ShouldDeleteSuccessfully()
        {
            // Arrange
            var id = Guid.NewGuid();
            var testData = new Stock { Id = id, stockName = "Stock A", Amount = 3 };
            _mockContext.Setup(c => c.Stocks.FindAsync(id)).ReturnsAsync(testData);

            // Act
            await _stockRepository.DeleteStockAsync(id);

            // Assert
            _mockContext.Verify(c => c.Stocks.Remove(testData), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task GetStockCountAsync_ValidId_ShouldReturnStockCount()
        {
            // Arrange
            var id = Guid.NewGuid();
            var testData = new Stock { Id = id, stockName = "Stock A", Amount = 3, Phones = new List<SmartPhone>() };
            testData.Phones.Add(new SmartPhone { Id = Guid.NewGuid(), Model = "Phone A", Price = 500.50, Avaiable = true, OperationalSystem = "Android", Memory = 8, Core = 4.0 });
            testData.Phones.Add(new SmartPhone { Id = Guid.NewGuid(), Model = "Phone B", Price = 600.75, Avaiable = false, OperationalSystem = "iOS", Memory = 12, Core = 6.0 });
            var mockDbSet = MockDbSet(new List<Stock> { testData });
            _mockContext.Setup(c => c.Stocks).Returns(mockDbSet.Object);

            // Act
            var result = await _stockRepository.GetStockCountAsync(id);

            // Assert
            Assert.Equal(testData.Phones.Count, result);
        }

        [Fact]
        public async Task AddsmartPhone_ValidStockId_ShouldAddSmartPhoneToStock()
        {
            // Arrange
            var stockId = Guid.NewGuid();
            var stock = new Stock { Id = stockId, stockName = "Stock A", Amount = 3 };
            var smartPhone = new SmartPhone { Id = Guid.NewGuid(), Model = "Phone C", Price = 700.00, Avaiable = true, OperationalSystem = "iOS", Memory = 16, Core = 8.0 };
            _mockContext.Setup(c => c.Stocks.FindAsync(stockId)).ReturnsAsync(stock);
            //_mockContext.Setup(c => c.SmartPhones.Add(smartPhone)).ReturnsAsync((EntityEntry<SmartPhone>)null);
            _mockContext.Setup(c => c.SaveChanges()).Returns(1);

            // Act
            var result = await _stockRepository.AddsmartPhone(stockId, smartPhone);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(smartPhone.Id, result.Id);
            Assert.Equal(smartPhone.Model, result.Model);
            Assert.Equal(smartPhone.Price, result.Price);
            Assert.Equal(smartPhone.Avaiable, result.Avaiable);
            Assert.Equal(smartPhone.OperationalSystem, result.OperationalSystem);
            Assert.Equal(smartPhone.Memory, result.Memory);
            Assert.Equal(smartPhone.Core, result.Core);
            _mockContext.Verify(c => c.SaveChanges(), Times.Exactly(2)); // Verifica que SaveChangesAsync foi chamado duas vezes (uma para AddAsync e uma para UpdateStockAsync)
        }

        private Mock<DbSet<T>> MockDbSet<T>(List<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            return mockDbSet;
        }
    }
}
