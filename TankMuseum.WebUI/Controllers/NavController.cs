using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TankMuseum.WebUI.Controllers
{
    public class NavController : Controller
    {
        public IExhibitRepository repository;

        public NavController(IExhibitRepository repo) {
            repository = repo; 
        }
        // GET: Nav
        public PartialViewResult Menu( string category = null, string subcategory = null)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedSubCategory = subcategory;
            IEnumerable<Exhibit> exhibits =(IEnumerable<Exhibit>) repository.Exhibits.GroupBy(x => x.Subcategory).Select(x=>x.FirstOrDefault()).Distinct().OrderBy(x => x.Category).ToList();
            return PartialView(exhibits);
        }
    }
}