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
    public class RateanAppointmentSteps
    {

        private readonly IMotherService _motherService;
        private readonly IMedicalAppointmentService _medicalappointmentService;

        private readonly Mock<IMotherRepository> _motherRepositoryMock = new Mock<IMotherRepository>();
        private readonly Mock<IMedicalAppointmentRepository> _medicalappointmentRepositoryMock = new Mock<IMedicalAppointmentRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        MotherResponse motherResponse;
        MedicalAppointment appointmentResponse;

        Mother mother = new Mother();
        MedicalAppointment appointment = new MedicalAppointment();
        int motherId = 101;
        int appointmentId = 102;
        int ranking;


        public RateanAppointmentSteps()
        {
            _motherService = new MotherService(_motherRepositoryMock.Object, _unitOfWorkMock.Object);
            _medicalappointmentService = new MedicalAppointmentService(_medicalappointmentRepositoryMock.Object, _unitOfWorkMock.Object);

            _medicalappointmentRepositoryMock.Setup(a => a.FindByIdAsync(appointmentId)).ReturnsAsync(appointment);
            _motherRepositoryMock.Setup(a => a.FindByIdAsync(motherId)).ReturnsAsync(mother);

        }

        [Given(@" The Mother wants to rate an appointment (.*)")]
        public void GivenTheMotherwantstorateanappointment()
        {
            Assert.NotNull(_motherService.GetByIdAsync(motherId));
        }


        [When(@"The Mother clicks on my appointments page (.*)")]
        public void WhenTheMotherclicksonmyappointmentspage()
        {
            Assert.AreEqual("Your appointments page will be shown", motherResponse.Message);
        }

        [Then(@"The system will show a message asking for a rate between 1 to 5 (.*)")]
        public void ThenThesystemwillshowamessageaskingforaratebetween1to5()
        {
            //Assert.AreEqual(_medicalappointmentService.GetByIdAsync(appointmentId).Result.Resource.Score, ranking);
        }
    }
}
