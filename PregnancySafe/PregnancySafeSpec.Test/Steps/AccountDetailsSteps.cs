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
    public class Verifymyaccount
    {

        ObstetricianResponse response;
        private readonly IObstetricianService _obstetricianService;

        private readonly Mock<IObstetricianRepository> _obstetricianRepositoryMock = new Mock<IObstetricianRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        string message = "Here it is your profile's information";

        Obstetrician obstetrician = new Obstetrician();
        int Id = 100;


        public Verifymyaccount()
        {
            _obstetricianService = new ObstetricianService(_obstetricianRepositoryMock.Object, _unitOfWorkMock.Object);

            //_obstetricianRepositoryMock.Setup(a => a.GetByIdAsync(Id)).ReturnsAsync(obstetrician);
        }


        [Given(@"a verified user (.*)")]
        public void Givenaverifieduser()
        {
            Assert.NotNull(_obstetricianService.GetByIdAsync(Id));
        }


        [When(@"the user clicks on his profile icon (.*)")]
        public void Whentheuserclicksonhisprofileicon()
        {
            response = _obstetricianService.GetByIdAsync(Id).Result;
        }

        [Then(@"the system will show your personal information (.*)")]
        public void Thenthesystemwillshowyourpersonalinformation()
        {
            Assert.AreEqual("Your profile will be shown to you right now", message);
        }
    }
}
