using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TankMuseum.WebUI.Controllers
{
    public class InfoController : Controller
    {
        private IExhibitRepository repository;

        public InfoController(IExhibitRepository repo)
        {
            repository = repo;
        }
        // GET: Info
        public ViewResult Info(int exhibitID)
        {
            TempData["returnUrl"] = Request.ServerVariables["HTTP_REFERER"];
            Exhibit exhibit = repository.Exhibits.FirstOrDefault(p => p.ExhibitID == exhibitID);
            return View(exhibit);

        }
    }
}