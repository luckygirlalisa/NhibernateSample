using Data;
using Domain.Entities;
using Helper;
using NUnit.Framework;

namespace MappingTest
{
    [TestFixture]
    public class CustomerMappingTest
    {
        private SessionManager sessionManager;
        
        [TestFixtureSetUp]
        public void Setup()
        {
            var session = new SessionCreator().GetSession();
            sessionManager = new SessionManager(session);
        }
        
        [Test]
        public void should_save_data_to_db_and_get_data_from_db_correctly()
        {
            var sourceCustomer = new Customer { FirstName = "Zhanfei", LastName = "Xiao" };
            
            sessionManager.CreateCustomer(sourceCustomer);
            Customer customer = sessionManager.GetCustomerById(1);
            
            int customerId = customer.Id;
            Assert.AreEqual(1, customerId);
        }
    }
}
