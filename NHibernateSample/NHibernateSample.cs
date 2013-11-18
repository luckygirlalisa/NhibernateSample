using NHibernate;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Data
{
    public class NHibernateSample
    {
        protected ISession Session { get; set; }

        public NHibernateSample(ISession session)
        {
            Session = session;
        }

        public void CreateCustomer(Customer customer)
        {
            Session.Save(customer);
            Session.Flush();
        }

        public Customer GetCustomerById(int customerId)
        {
            return Session.Get<Customer>(customerId);
        }
    }
}
