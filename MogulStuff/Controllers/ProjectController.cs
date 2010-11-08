using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MogulStuff.Domain;
using System.Transactions;

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
                project.Issues.Add(new Issue { Title = "This is serious stuff." });
                projectRepository.Add(project);
                trans.Complete();
            }
            return Redirect("/Project/");
        }
    }
}
