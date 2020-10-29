using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using PregnancySafe.Domain.Models;
using PregnancySafe.Services;
using PregnancySafe.Domain.Services.Communication;
using PregnancySafe.Domain.Repositories;
using FluentAssertions;

namespace PregnancySafe.Test
{
    public class ChatServiceTest
    {
        [SetUp]
        public void Setup()
        { 
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsChatNotFoundResponse()
        {
            //Arrange
            var mockChatRepository = GetDefaultChatRepositoryInstance();
            var chatId = 1;
            mockChatRepository.Setup(r => r.FindByIdAsync(chatId)).Returns(Task.FromResult<Chat>(null));
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new ChatService(mockChatRepository.Object, mockUnitofWork.Object);
            //Act
            ChatResponse response = await service.GetByIdAsync(chatId);
            var message = response.Message;
            //Assert
            message.Should().Be("Chat not found");
        }
        private Mock<IChatRepository> GetDefaultChatRepositoryInstance()
        {
            return new Mock<IChatRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}