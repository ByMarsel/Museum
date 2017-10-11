using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TankMuseum.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IExhibitRepository repository;

        public AdminController(IExhibitRepository repo) {
            repository = repo; 
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Exhibits);
        }

        public ViewResult Edit(int exhibitID) {
            Exhibit exhibit = repository.Exhibits.FirstOrDefault(p => p.ExhibitID == exhibitID);
            return View (exhibit);

        }
        [HttpPost]
        public ActionResult Edit(Exhibit exhibit, HttpPostedFileWrapper image) {
            if (ModelState.IsValid) {
                if (image != null) {
                    exhibit.ImageMimeType = image.ContentType;
                    exhibit.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(exhibit.ImageData, 0, image.ContentLength);
                }
                repository.SaveExhibit(exhibit);
                TempData["message"] = string.Format("{0} сохранен!", exhibit.Name);
                return RedirectToAction("Index");
            }else
            {
                return View(exhibit);
            }
        }
        public ViewResult Create() {
            return View("Edit", new Exhibit());
        }
        [HttpPost]
        public ActionResult Delete(int exhibitID) {
            Exhibit deletedExibit = repository.DeleteExhibit(exhibitID);
            TempData["message"] = string.Format("{0} удален.", deletedExibit.Name);
            return RedirectToAction("Index");
        }
    }
}