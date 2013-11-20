using System.Collections.Generic;
using Domain.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Helper
{
    public class SessionManager
    {
        protected ISession Session { get; set; }

        public SessionManager(ISession session)
        {
            Session = session;
        }

#region save entries to db
        
        public void CreateCustomer(Customer customer)
        {
            Session.Save(customer);
            Session.Flush();
        }

#endregion

#region get entries from db

        public Customer GetCustomerById(int customerId)
        {
            return Session.Get<Customer>(customerId);
        } 
        
        public IList<Customer> GetCustomerByFirstName(string firstName)
        {
            return Session.CreateCriteria<Customer>().Add(Restrictions.Eq("FirstName", firstName)).List<Customer>();
        }

        public void DeleteCustomer(Customer customer)
        {
            Session.Delete(customer);
        }

        public IList<Customer> GetAllCustomer()
        {
            return Session.CreateQuery("from Customer").List<Customer>();
        }

        public IList<Customer> GetCustomerByLastName1(string lastName)
        {
            return Session.CreateQuery("from Customer c where c.LastName = '"+lastName+"'  ").List<Customer>();
        }

        public IList<Customer> GetCustomerByLastName2(string lastName)
        {
            return Session.CreateQuery("from Customer c where c.LastName = ?")
                          .SetParameter(0, lastName)
                          .List<Customer>();
        }

        public IList<Customer> GetCustomerByLastNameTestForTwoParameters(string lastName, int id)
        {
            return Session.CreateQuery("from Customer c where c.LastName = ? and id = ?")
                          .SetParameter(0, lastName)
                          .SetParameter(1, id)
                          .List<Customer>();
        }

        public IList<Customer> GetCustomerByLastName3(string lastName)
        {
            return Session.CreateQuery("from Customer c where c.LastName = :LastName")
                          .SetParameter("LastName",lastName)
                          .List<Customer>();
        }

        public IList<Customer> GetCustomerByLastNameWithCriteria(string lastName)
        {
            return Session.CreateCriteria<Customer>()
                          .Add(Restrictions.Eq("LastName", lastName))
                          .List<Customer>();
        }

        public IList<Customer> GetCustomerByLettersWithCriteria()
        {
            return Session.CreateCriteria<Customer>()
                          .SetMaxResults(5)
                          .Add(Restrictions.Between("LastName", "w%", "y%"))
                          .List<Customer>();
        } 

        public IList<Customer> GetCustomerByIdRuleWithCriteria()
        {
            return Session.CreateCriteria<Customer>()
                          .Add(Restrictions.Gt("Id", 10))
                          .List<Customer>();
        }

        public IList<Customer> GetCustomerBySample(Customer customerSample)
        {
            Example example = Example.Create(customerSample).IgnoreCase()
                                     .EnableLike()
                                     .SetEscapeCharacter('&');
            return Session.CreateCriteria<Customer>()
                          .Add(example)
                          .List<Customer>();
        }

# endregion

        #region delete entries from db
        #endregion
    }
}
