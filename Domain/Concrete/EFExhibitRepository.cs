using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
   public class EFExhibitRepository: IExhibitRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Exhibit> Exhibits
        {
            get
            {
                return context.Exhibits; 
            }
        }

        public Exhibit DeleteExhibit(int exhibitID)
        {
            Exhibit dbEntry = context.Exhibits.Find(exhibitID);
            if (dbEntry != null) {
                context.Exhibits.Remove(dbEntry);
                context.SaveChanges(); 
            }
            return dbEntry; 
        }

        public void SaveExhibit(Exhibit exhibit)
        {
            if (exhibit.ExhibitID == 0) {
                context.Exhibits.Add(exhibit);
            }
            else
            {
                Exhibit dbEntry = context.Exhibits.Find(exhibit.ExhibitID);
                if (dbEntry != null) {
                    dbEntry.Name = exhibit.Name;
                    dbEntry.Description = exhibit.Description;
                    dbEntry.Availability = exhibit.Availability;
                    dbEntry.Category = exhibit.Category;
                    dbEntry.Subcategory = exhibit.Subcategory;
                    dbEntry.ImageData = exhibit.ImageData;
                    dbEntry.ImageMimeType = exhibit.ImageMimeType;
                }

            }
            context.SaveChanges(); 
        }
    }
}
