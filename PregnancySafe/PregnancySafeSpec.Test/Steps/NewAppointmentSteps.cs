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
    public class Schedulenewappointment
    {

        Mother mother;
        MedicalAppointment validappointment; 
 
        MedicalAppointmentResponse appointmentResponse;

        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly Mock<IMedicalAppointmentRepository> _medicalAppointmentRepositoryMock = new Mock<IMedicalAppointmentRepository>();
        private readonly Mock<IMotherRepository> _motherRepositoryMock = new Mock<IMotherRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        
        public Schedulenewappointment()
        {
            mother = new Mother
            {
                Id = 10,
                FirstName = "Fernanda",
                LastName = "Pérez",
                Age = 20,
                Email = "fernandaperez@gmail.com"
            };

            _medicalAppointmentService = new MedicalAppointmentService(
                _medicalAppointmentRepositoryMock.Object,
                _unitOfWorkMock.Object);

            _medicalAppointmentRepositoryMock.Setup(or => or.AddASync(validappointment)).Returns(new Task(action: new Action(() => new MedicalAppointmentResponse(validappointment))));
        }


        [Given(@"I am in my medical appointment (.*)")]
        public void GivenIaminmymedicalappointment()
        {
            validappointment = new MedicalAppointment
            {
                Id = 100,
                ObstetricianId = 10,
                MotherId = 10
            };
        }


        [When(@"Press the option to schedule new appointment (.*)")]
        public void WhenPresstheoptiontoschedulenewappointment()
        {
            appointmentResponse = _medicalAppointmentService.SaveAsync(validappointment).Result;
        }

        [Then(@"Valid my next appointment (.*)")]
        public void ThenValidmynextappointment()
        {
            Assert.IsTrue(appointmentResponse.Success);
        }
    }
}
