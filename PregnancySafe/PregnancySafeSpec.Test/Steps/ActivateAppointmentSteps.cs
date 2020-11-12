using PregnancySafe.Domain.Models;
using PregnancySafe.Domain.Services;
using PregnancySafe.Domain.Services.Communication;
using TechTalk.SpecFlow;
using Moq;
using PregnancySafe.Domain.Repositories;
using System.Net.Cache;
using Org.BouncyCastle.Asn1.Misc;
using PregnancySafe.Services;
using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PregnancySafeSpec.Test.Steps
{
    [Binding]
    public class ActivateAppointmentSteps
    {

        private readonly IMedicalAppointmentService _medicalappointmentService;
        private readonly Mock<IMedicalAppointmentRepository> _medicalappointmentRepositoryMock = new Mock<IMedicalAppointmentRepository>();
        private readonly Mock<IMotherRepository> _motherRepositoryMock = new Mock<IMotherRepository>();
        private readonly IMotherService _motherService;
        
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        MedicalAppointment appointment = new MedicalAppointment();
        int appointmentId = 1;
        int motherId = 2;
        Mother mother = new Mother();


        public ActivateAppointmentSteps()
        {
            _medicalappointmentService = new MedicalAppointmentService(_medicalappointmentRepositoryMock.Object, _unitOfWorkMock.Object);
            _motherService = new MotherService(_motherRepositoryMock.Object, _unitOfWorkMock.Object);

            _motherRepositoryMock.Setup(a => a.GetByIdAsync(motherId)).ReturnsAsync(mother);
            _medicalappointmentRepositoryMock.Setup(r => r.FindByIdAsync(appointmentId).ReturnsAsync(appointment));
        }

        private void ReturnsAsync(Mother mother)
        {
            throw new NotImplementedException();
        }

        [Given(@"a mother has an appointment (.*)")]
        public void Givenamotherhasanappointment()
        {
           
        }


        [When(@"the mother clicks on join appointment (.*)")]
        public void Whenthemotherclicksonjoinappointment()
        {
            var response = _medicalappointmentService.UpdateAsync(motherId, appointment).Result;
        }

        [Then(@"the system will show your personal information (.*)")]
        public void Thenthesystemwillshowyourpersonalinformation()
        {
            Assert.IsTrue(_medicalappointmentService.SaveAsync(appointment).Result.Success);
        }
    }
}
