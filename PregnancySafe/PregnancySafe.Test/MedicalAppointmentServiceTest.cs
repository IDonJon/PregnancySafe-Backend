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
    public class MedicalAppointmentServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsMedicalAppointmentNotFoundResponse()
        {
            //Arrange
            var mockMedicalAppointmentRepository = GetDefaultMedicalAppointmentRepositoryInstance();
            var medicalAppointmentId = 1;
            mockMedicalAppointmentRepository.Setup(r => r.FindByIdAsync(medicalAppointmentId)).Returns(Task.FromResult<MedicalAppointment>(null));
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new MedicalAppointmentService(mockMedicalAppointmentRepository.Object, mockUnitofWork.Object);
            //Act
            MedicalAppointmentResponse response = await service.GetByIdAsync(medicalAppointmentId);
            var message = response.Message;
            //Assert
            message.Should().Be("Medical Appointment not found");
        }
        [Test]
        public async Task GetAllAsyncWhenNoMedicalAppointmentReturnsEmptyCollection()
        {
            //Arrange
            var mockMedicalAppointmentRepository = GetDefaultMedicalAppointmentRepositoryInstance();
            mockMedicalAppointmentRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<MedicalAppointment>());
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new MedicalAppointmentService(mockMedicalAppointmentRepository.Object, mockUnitofWork.Object);
            //Act
            List<MedicalAppointment> appointments = (List<MedicalAppointment>)await service.ListAsync();
            var appointmentsCount = appointments.Count;
            //Assert
            appointmentsCount.Should().Equals(0);
        }
        private Mock<IMedicalAppointmentRepository> GetDefaultMedicalAppointmentRepositoryInstance()
        {
            return new Mock<IMedicalAppointmentRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

    }
}