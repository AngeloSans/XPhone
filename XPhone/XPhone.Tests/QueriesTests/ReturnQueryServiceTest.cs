using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPhone.Application.Queries;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;

namespace XPhone.Application.Tests.Queries
{
    public class ReturnQueryServiceTests
    {
        private Mock<IReturnRepository> _mockReturnRepository;
        private ReturnQueryService _returnQueryService;

        public ReturnQueryServiceTests()
        {
            _mockReturnRepository = new Mock<IReturnRepository>();
            _returnQueryService = new ReturnQueryService(_mockReturnRepository.Object);
        }

        [Fact]
        public async Task GetAllReturnAsync_ShouldReturnListOfReturns()
        {
            
            var expectedReturns = new List<Return>
            {
                new Return { Id = Guid.NewGuid(), ReturnDate = DateTime.Now, Condition = true, RentId = Guid.NewGuid() },
                new Return { Id = Guid.NewGuid(), ReturnDate = DateTime.Now, Condition =true, RentId = Guid.NewGuid() }
            };
            _mockReturnRepository.Setup(repo => repo.GetReturnListAsync()).ReturnsAsync(expectedReturns);

            
            var result = await _returnQueryService.GetAllReturnAsync();

            
            Assert.Equal(expectedReturns.Count, result.Count());
        }

        [Fact]
        public async Task GetReturnAsync_ValidId_ShouldReturnReturnDTO()
        {
            
            var id = Guid.NewGuid();
            var returnEntity = new Return { Id = id, ReturnDate = DateTime.Now, Condition = true, RentId = Guid.NewGuid() };
            _mockReturnRepository.Setup(repo => repo.GetReturnAsync(id)).ReturnsAsync(returnEntity);

           
            var result = await _returnQueryService.GetReturnAsync(id);

           
            Assert.NotNull(result);
            Assert.Equal(returnEntity.Id, result.Id);
            Assert.Equal(returnEntity.ReturnDate, result.ReturnDate);
            Assert.Equal(returnEntity.Condition, result.Condition);
            Assert.Equal(returnEntity.RentId, result.RentId);
        }

        [Fact]
        public async Task GetReturnAsync_InvalidId_ShouldThrowKeyNotFoundException()
        {
            
            var id = Guid.NewGuid();
            _mockReturnRepository.Setup(repo => repo.GetReturnAsync(id)).ReturnsAsync((Return)null); // Simulate return entity not found

           
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _returnQueryService.GetReturnAsync(id));
        }
    }
}
