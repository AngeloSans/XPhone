/*using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Text;
using System.Threading.Tasks;
using XPhone.Application.Handler;
using XPhone.Application.Command;
using XPhone.Domain.Entities;
using XPhone.Infrastructure.Repository;

namespace XPhone.Tests.CommandTests
{
    public class CreateClientCommandHandlerTests
    {
        [Fact]
        public async Task HandlerAsync_ValidCommand_AddsClient()
        {
            
            var mockClientRepository = new Mock<IClientRepository>();
            var handler = new CreateClientCommandHandler(mockClientRepository.Object);
            var command = new CreateClientCommand
            {
                Email = "test@example.com",
                Name = "Test User",
                Fine = true,
                FineAmount = 0,
                Phone = "1234567890"
            };

            
            var clientId = await handler.HandlerAsync(command);

            
            mockClientRepository.Verify(repo => repo.AddClientAsync(It.Is<Client>(
                c => c.Email == command.Email &&
                     c.Name == command.Name &&
                     c.Fine == command.Fine &&
                     c.FineAmount == command.FineAmount &&
                     c.Phone == command.Phone)), Times.Once);
            Assert.NotEqual(Guid.Empty, clientId);
        }
    }
}
*/