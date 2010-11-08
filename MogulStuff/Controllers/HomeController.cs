using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MogulStuff.Domain;

namespace MogulStuff.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IProjectRepository projectRepo;

        public HomeController(IProjectRepository projectRepo) {
            this.projectRepo = projectRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View(projectRepo.GetProjects(null).ToList());
        }



        public ActionResult About()
        {
            return View();
        }
    }
}
