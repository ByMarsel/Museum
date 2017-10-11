using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
   public interface IExhibitRepository
    {
        IQueryable<Exhibit> Exhibits { get; }
        void SaveExhibit(Exhibit exhibit);

        Exhibit DeleteExhibit(int exhibitID); 
    }
}
