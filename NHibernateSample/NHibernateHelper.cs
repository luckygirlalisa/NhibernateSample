using NHibernate;
using NHibernate.Cfg;

namespace NHibernateSample.Data
{
    public class NhibernateHelper
    {
        private ISessionFactory _sessionFactory;

        public NhibernateHelper()
        {
            _sessionFactory = GetSessionFactory();
        }

        private ISessionFactory GetSessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
