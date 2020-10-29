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
    public class MotherServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsMotherNotFoundResponse()
        {
            //Arrange
            var mockMotherRepository = GetDefaultMotherRepositoryInstance();
            var motherId = 1;
            mockMotherRepository.Setup(r => r.FindByIdAsync(motherId)).Returns(Task.FromResult<Mother>(null));
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new MotherService(mockMotherRepository.Object, mockUnitofWork.Object);
            //Act
            MotherResponse response = await service.GetByIdAsync(motherId);
            var message = response.Message;
            //Assert
            message.Should().Be("Mother not found");
        }
        private Mock<IMotherRepository> GetDefaultMotherRepositoryInstance()
        {
            return new Mock<IMotherRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

    }
}