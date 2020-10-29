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
    public class ObstetricianServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsObstetricianNotFoundResponse()
        {
            //Arrange
            var mockObstetricianRepository = GetDefaultObstetricianRepositoryInstance();
            var obstetricianId = 1;
            mockObstetricianRepository.Setup(r => r.FindByIdAsync(obstetricianId)).Returns(Task.FromResult<Obstetrician>(null));
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new ObstetricianService(mockObstetricianRepository.Object, mockUnitofWork.Object);
            //Act
            ObstetricianResponse response = await service.GetByIdAsync(obstetricianId);
            var message = response.Message;
            //Assert
            message.Should().Be("Obstetrician not found");
        }

        
        private Mock<IObstetricianRepository> GetDefaultObstetricianRepositoryInstance()
        {
            return new Mock<IObstetricianRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }


    }
}