using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PregnancySafe.Test
{
    public class ChatServiceTest
    {
     

            [Given("the first number is (.*)")]
            public void GivenTheFirstNumberIs(int number)
            {
                //TODO: implement arrange (precondition) logic
                // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
                // To use the multiline text or the table argument of the scenario,
                // additional string/Table parameters can be defined on the step definition
                // method. 

               
            }

        
            [When("the two numbers are added")]
            public void WhenTheTwoNumbersAreAdded()
            {
                //TODO: implement act (action) logic

               
            }

            [Then("the result should be (.*)")]
            public void ThenTheResultShouldBe(int result)
            {
                //TODO: implement assert (verification) logic

                
            }
    }
}