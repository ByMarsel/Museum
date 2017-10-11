using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ExhibitController : Controller
    {
        private IExhibitRepository repo;

        public ExhibitController(IExhibitRepository exhibitRepository) {
            this.repo = exhibitRepository; 
        }

        public ViewResult List() {
            return View(repo.Exhibits);
        }
       
    }
}