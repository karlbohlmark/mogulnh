using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MogulStuff.Domain
{
    public class Issue
    {
        public virtual int Id{get;set;}
        public virtual string Title { get; set; }
    }

    public class Project {
        public Project() {
            Issues = new List<Issue>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Issue> Issues { get; private set; }
    }

    public interface IProjectRepository {
        IEnumerable<Project> GetProjects(Func<Project, bool> filter);
        void Add(Project project);
    }
}
