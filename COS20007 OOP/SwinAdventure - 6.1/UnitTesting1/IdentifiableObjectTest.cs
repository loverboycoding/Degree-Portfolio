using NUnit.Framework;
using SwinAdventure; 

namespace UnitTesting1
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        [Test]
        public void TestAreYou()
        {
            
            string[] ids = { "fred", "bob" };
            IdentifiableObject obj = new IdentifiableObject(ids);

            
            bool resultFred = obj.AreYou("fred");
            bool resultBob = obj.AreYou("bob");
            bool resultWilma = obj.AreYou("wilma");

            
            Assert.That(resultFred, Is.True); 
            Assert.That(resultBob, Is.True); 
            Assert.That(resultWilma, Is.False); 
        }

        [Test]
        public void TestNotAreYou()
        {
            
            string[] ids = { "fred", "bob" };
            IdentifiableObject obj = new IdentifiableObject(ids);

            
            bool resultWilma = obj.AreYou("wilma");
            bool resultBoby = obj.AreYou("boby");

            
            Assert.That(resultWilma, Is.False); 
            Assert.That(resultBoby, Is.False); 
        }

        [Test]
        public void TestCaseSensitive()
        {
            
            string[] ids = { "fred", "bob" };
            IdentifiableObject obj = new IdentifiableObject(ids);

            
            bool resultFredUpper = obj.AreYou("FRED");
            bool resultBobLower = obj.AreYou("bOB");

            
            Assert.That(resultFredUpper, Is.True); // Check case insensitivity for "fred"
            Assert.That(resultBobLower, Is.True); // Check case insensitivity for "bob"
        }

        [Test]
        public void TestFirstId()
        {
           
            string[] ids = { "fred", "bob" };
            IdentifiableObject obj = new IdentifiableObject(ids);

            
            string firstId = obj.FirstId;

            
            Assert.That(firstId, Is.EqualTo("fred")); 
        }

        [Test]
        public void TestFirstIdWithNoIds()
        {
           
            IdentifiableObject obj = new IdentifiableObject(new string[] { });

            
            string firstId = obj.FirstId;

            
            Assert.That(firstId, Is.EqualTo(string.Empty)); 
        }

        [Test]
        public void TestAddId()
        {
            // Arrange
            string[] ids = { "fred", "bob" };
            IdentifiableObject obj = new IdentifiableObject(ids);
            obj.AddIdentifier("wilma"); 

            
            bool resultWilma = obj.AreYou("wilma");

            // Assert
            Assert.That(resultWilma, Is.True);
        }
    }
}
