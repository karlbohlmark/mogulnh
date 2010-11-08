using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MogulStuff.Domain;

namespace MogulStuff.Models
{
    public class ProjectList
    {
        public IList<Project> Projects { get; set; }
    }
}