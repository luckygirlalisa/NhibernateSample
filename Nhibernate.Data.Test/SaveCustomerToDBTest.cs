using Domain.Entities;
using Helper;
using NHibernate.Util;
using NUnit.Framework;

namespace MappingTest
{
    [TestFixture]
    public class SaveCustomerToDBTest
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
            var sourceCustomer = new Customer { FirstName = "Xiaozhi", LastName = "Xiao" };
            
            sessionManager.CreateCustomer(sourceCustomer);
            
            Customer customer = sessionManager.GetCustomerByFirstName("Xiaozhi").First() as Customer;

            Assert.That(customer.FirstName, Is.EqualTo("Xiaozhi"));
        }

       
    }
}
