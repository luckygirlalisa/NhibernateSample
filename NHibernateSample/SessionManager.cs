using Domain.Entities;
using NHibernate;

namespace Data
{
    public class SessionManager
    {
        protected ISession Session { get; set; }

        public SessionManager(ISession session)
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
