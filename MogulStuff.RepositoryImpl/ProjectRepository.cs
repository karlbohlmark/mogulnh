using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MogulStuff.Domain;
using NHibernate;
using NHibernate.Linq;

namespace MogulStuff.RepositoryImpl
{
    public class ProjectRepository : IProjectRepository
    {

        private ISession session;
        public ProjectRepository(ISession session) {
            this.session = session;
        } 

        public IEnumerable<Project> GetProjects(Func<Project, bool> filter)
        {
            IQueryable<Project> proj = session.Query<Project>();
            return filter==null? proj : proj.Where(filter);
        }


        public void Add(Project project)
        {
            session.Save(project);
        }
    }
}
