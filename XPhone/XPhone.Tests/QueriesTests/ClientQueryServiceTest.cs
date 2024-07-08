/*using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using XPhone.Application.Queries;
using XPhone.Domain.Entities;
using XPhone.Domain.Entities.DTO;
using XPhone.Infrastructure.Repository;

namespace XPhone.Tests.Queries
{
    public class ClientQueryServiceTests
    {
        [Fact]
        public async Task GetAllClientsAsync_ReturnsAllClients()
        {
            var mockClientRepository = new Mock<IClientRepository>();
            var clients = new List<Client>
            {
                new Client { Id = Guid.NewGuid(), Name = "Client1", Phone = "1234567890", Fine = true, FineAmount = 0 },
                new Client { Id = Guid.NewGuid(), Name = "Client2", Phone = "0987654321", Fine = true, FineAmount = 50 }
            };
            mockClientRepository.Setup(repo => repo.GetAllClientsAsync()).ReturnsAsync(clients);

            var queryService = new ClientQueryService(mockClientRepository.Object);

            var result = await queryService.GetAllClientsAsync();

          
            Assert.Equal(clients.Count, result.Count);

            for (int i = 0; i < clients.Count; i++)
            {
                Assert.Equal(clients[i].Id, result[i].Id);
                Assert.Equal(clients[i].Name, result[i].Name);
                Assert.Equal(clients[i].Phone, result[i].Phone);
                Assert.Equal(clients[i].Fine, result[i].Fine);
                Assert.Equal(clients[i].FineAmount, result[i].FineAmount);
                
            }
        }


        [Fact]
        public async Task GetClientByIdAsync_ExistingClient_ReturnsClientDTO()
        {
         
            var mockClientRepository = new Mock<IClientRepository>();
            var clientId = Guid.NewGuid();
            var client = new Client
            {
                Id = clientId,
                Name = "Client1",
                Phone = "1234567890",
                Fine = true,
                FineAmount = 0,
                Rents = new List<Rent>()
            };
            mockClientRepository.Setup(repo => repo.GetClientByIdAsync(clientId)).ReturnsAsync(client);

            var queryService = new ClientQueryService(mockClientRepository.Object);

           
            var result = await queryService.GetClientByIdAsync(clientId);

          
            Assert.NotNull(result);
            Assert.Equal(clientId, result.Id);
            Assert.Equal(client.Name, result.Name);
            Assert.Equal(client.Phone, result.Phone);
            Assert.Equal(client.Fine, result.Fine);
            Assert.Equal(client.FineAmount, result.FineAmount);
            Assert.Equal(client.Rents, result.Rents);
        }

        [Fact]
        public async Task GetClientByIdAsync_NonExistingClient_ThrowsKeyNotFoundException()
        {
 
            var mockClientRepository = new Mock<IClientRepository>();
            var clientId = Guid.NewGuid();
            mockClientRepository.Setup(repo => repo.GetClientByIdAsync(clientId)).ReturnsAsync((Client)null);

            var queryService = new ClientQueryService(mockClientRepository.Object);


            await Assert.ThrowsAsync<KeyNotFoundException>(() => queryService.GetClientByIdAsync(clientId));
        }
    }
}
*/