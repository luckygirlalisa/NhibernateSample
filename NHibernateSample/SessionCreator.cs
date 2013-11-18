using NHibernate;
using NHibernate.Cfg;

namespace Helper
{
    public class SessionCreator
    {
        private readonly ISessionFactory sessionFactory;

        public SessionCreator()
        {
            sessionFactory = GetSessionFactory();
        }

        private ISessionFactory GetSessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        public ISession GetSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
