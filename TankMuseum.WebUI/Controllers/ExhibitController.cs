using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using TankMuseum.WebUI.Models;

namespace WebUI.Controllers
{
    public class ExhibitController : Controller
    {
        private IExhibitRepository repo;
        public int PageSize = 6; 
        public ExhibitController(IExhibitRepository exhibitRepository) {
            this.repo = exhibitRepository; 
        }

        public ViewResult List(string category, string subcategory,  int page = 1 ) {
          
            ExhibitsListViewModel model = new ExhibitsListViewModel
            {
                Exhibits = repo.Exhibits.Where(p=> category == null|| p.Category == category && subcategory == null
                || p.Category == category &&p.Subcategory==subcategory ).OrderBy(p => p.ExhibitID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize,
                    TotalItems = repo.Exhibits.Where(p => category == null || p.Category == category && subcategory == null
                || p.Category == category && p.Subcategory == subcategory).Count() }, 
                CurrentCategory = category,
                CurrentSubcategory = subcategory
            };

            return View(model);
        }
        public FileContentResult GetImage(int exhibitId) {
            Exhibit prod = repo.Exhibits.FirstOrDefault(p => p.ExhibitID == exhibitId);
            if (prod != null) {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}