using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using MogulStuff.Domain;
using MogulStuff.RepositoryImpl;

namespace MogulStuff
{
    public class Registry : StructureMap.Configuration.DSL.Registry
    {
        public Registry() {
            For<ISessionFactory>().Singleton().Use(NHibernateConfig.BuildSessionFactory());
            For<ISession>().HttpContextScoped().Use(context => context.GetInstance<ISessionFactory>().OpenSession());
            For<IProjectRepository>().Use<ProjectRepository>();
        }
    }
}