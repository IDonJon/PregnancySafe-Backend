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
    public class MedicalExamServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsMedicalExamNotFoundResponse()
        {
            //Arrange
            var mockMedicalExamRepository = GetDefaultMedicalExamRepositoryInstance();
            var medicalExamId = 1;
            mockMedicalExamRepository.Setup(r => r.FindByIdAsync(medicalExamId)).Returns(Task.FromResult<MedicalExam>(null));
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new MedicalExamService(mockMedicalExamRepository.Object, mockUnitofWork.Object);
            //Act
            MedicalExamResponse response = await service.GetByIdAsync(medicalExamId);
            var message = response.Message;
            //Assert
            message.Should().Be("Medical Exam not found");
        }
        [Test]
        public async Task GetAllAsyncWhenNoMedicalExamReturnsEmptyCollection()
        {
            //Arrange
            var mockMedicalExamRepository = GetDefaultMedicalExamRepositoryInstance();
            mockMedicalExamRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<MedicalExam>());
            var mockUnitofWork = GetDefaultIUnitOfWorkInstance();
            var service = new MedicalExamService(mockMedicalExamRepository.Object, mockUnitofWork.Object);
            //Act
            List<MedicalExam> exams= (List<MedicalExam>)await service.ListAsync();
            var examsCount = exams.Count;
            //Assert
            examsCount.Should().Equals(0);
        }
        private Mock<IMedicalExamRepository> GetDefaultMedicalExamRepositoryInstance()
        {
            return new Mock<IMedicalExamRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }


    }
}