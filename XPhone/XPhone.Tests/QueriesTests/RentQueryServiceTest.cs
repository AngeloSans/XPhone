using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using XPhone.Application.Queries;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infra.Repository;

namespace XPhone.Tests.Queries
{
    public class RentQueryServiceTests
    {
        [Fact]
        public async Task GetAllRentAsync_ReturnsAllRents()
        {
            var mockRentRepository = new Mock<IRentRepository>();
            var rents = new List<Rent>
            {
                new Rent { Id = Guid.NewGuid(), Devolution = true, EndDate = DateTime.Now.AddDays(2), StartDate = DateTime.Now, ClientId = Guid.NewGuid(), SmartPhoneId = Guid.NewGuid() },
                new Rent { Id = Guid.NewGuid(), Devolution = false, EndDate = DateTime.Now.AddDays(3), StartDate = DateTime.Now, ClientId = Guid.NewGuid(), SmartPhoneId = Guid.NewGuid() }
            };
            mockRentRepository.Setup(repo => repo.GetAllRentAsync()).ReturnsAsync(rents);

            var queryService = new RentQueryService(mockRentRepository.Object);

   
            var result = await queryService.GetAllRentAsync();

            Assert.Equal(rents.Count, result.Count());
            foreach (var rentDto in result)
            {
                var rent = rents.Single(r => r.Id == rentDto.Id);
                Assert.Equal(rent.Devolution, rentDto.Devolution);
                Assert.Equal(rent.EndDate, rentDto.EndDate);
                Assert.Equal(rent.StartDate, rentDto.StartDate);
                Assert.Equal(rent.ClientId, rentDto.ClientId);
                Assert.Equal(rent.SmartPhoneId, rentDto.SmartPhoneId);
            }
        }

        [Fact]
        public async Task GetRentByIdAsync_ExistingRent_ReturnsRentDTO()
        {
            
            var mockRentRepository = new Mock<IRentRepository>();
            var rentId = Guid.NewGuid();
            var rent = new Rent
            {
                Id = rentId,
                Devolution = true,
                EndDate = DateTime.Now.AddDays(2),
                StartDate = DateTime.Now,
                ClientId = Guid.NewGuid(),
                SmartPhoneId = Guid.NewGuid()
            };
            mockRentRepository.Setup(repo => repo.GetRentByIdAsync(rentId)).ReturnsAsync(rent);

            var queryService = new RentQueryService(mockRentRepository.Object);

            
            var result = await queryService.GetRentByIdAsync(rentId);

            
            Assert.NotNull(result);
            Assert.Equal(rentId, result.Id);
            Assert.Equal(rent.Devolution, result.Devolution);
            Assert.Equal(rent.EndDate, result.EndDate);
            Assert.Equal(rent.StartDate, result.StartDate);
            Assert.Equal(rent.ClientId, result.ClientId);
            Assert.Equal(rent.SmartPhoneId, result.SmartPhoneId);
        }

        [Fact]
        public async Task GetRentByIdAsync_NonExistingRent_ThrowsKeyNotFoundException()
        {
            
            var mockRentRepository = new Mock<IRentRepository>();
            var rentId = Guid.NewGuid();
            mockRentRepository.Setup(repo => repo.GetRentByIdAsync(rentId)).ReturnsAsync((Rent)null);

            var queryService = new RentQueryService(mockRentRepository.Object);

            await Assert.ThrowsAsync<KeyNotFoundException>(() => queryService.GetRentByIdAsync(rentId));
        }
    }
}
