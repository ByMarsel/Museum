using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankMuseum.WebUI.Models
{
    public class ExhibitsListViewModel
    {
        public IEnumerable<Exhibit> Exhibits { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        public string CurrentSubcategory { get; set; }
    }
}