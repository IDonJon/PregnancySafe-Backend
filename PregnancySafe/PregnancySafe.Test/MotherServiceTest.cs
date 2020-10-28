using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PregnancySafe.Test
{
    public class MotherServiceTest
    {

            [Given("the user is in the landing page(.*)")]
            public void UserIsInTheLandingPage(int number)
            {
         
                ScenarioContext.Current.Pending();
            }

            [When("clicks register button and fill the form")]
            public void ClicksRegisterButtonAndFillTheForm()
            {
          

                ScenarioContext.Current.Pending();
            }

            [Then("the result should be (.*)")]
            public void ThenTheResultShouldBe(int result)
            {

                ScenarioContext.Current.Pending();

            }
        
    }
}