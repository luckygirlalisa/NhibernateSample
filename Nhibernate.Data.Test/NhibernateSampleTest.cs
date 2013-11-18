using NHibernateSample.Data;
using NHibernateSample.Domain.Entities;
using NUnit.Framework;

namespace Nhibernate.Data.Test
{
    [TestFixture]
    public class NhibernateSampleTest
    {
        private NHibernateSample.Data.NHibernateSample _sample;
        [TestFixtureSetUp]
        public void Setup()
        {
            var session = new NhibernateHelper().GetSession();
            _sample = new NHibernateSample.Data.NHibernateSample(session);
        }
        [Test]
        public void GetCustomerByIdTest()
        {
            var tempCutomer = new Customer { FirstName = "Zhanfei", LastName = "Xiao" };
            _sample.CreateCustomer(tempCutomer);
            Customer customer = _sample.GetCustomerById(1);
            int customerId = customer.Id;
            Assert.AreEqual(1, customerId);
        }
    }
}
