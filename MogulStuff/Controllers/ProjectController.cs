using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MogulStuff.Domain;
using System.Transactions;
using StructureMap;
using NHibernate;

namespace MogulStuff.Controllers
{
    public class ProjectController : Controller
    {
        IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository) {
            this.projectRepository = projectRepository;
        }


        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View("List", projectRepository.GetProjects(null).ToList());
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Project project)
        {
            using (var trans = new TransactionScope()) {
                project.Issues.Add(new Issue { Title = "To illustrate cascading persistance, here is an issue for: " + project.Name });
                projectRepository.Add(project);
                trans.Complete();
            }
            return Redirect("/Project/");
        }

        [HttpGet]
        public ActionResult Hql(string query) {
            return Json(ObjectFactory.GetInstance<ISession>().CreateQuery(query).List(), JsonRequestBehavior.AllowGet);
        }
    }
}
