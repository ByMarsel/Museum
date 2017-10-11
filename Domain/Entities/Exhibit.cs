using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Exhibit
    {
        [HiddenInput(DisplayValue = false)]
        public int ExhibitID { get; set; }
        [DisplayName("Наименование")]
        [Required(ErrorMessage = "Введите наименование экспоната!")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Описание")]
        [Required(ErrorMessage = "Описание не может быть пустым!")]
        public string Description { get; set; }
        [DisplayName("Категория")]
        [Required(ErrorMessage = "Категория обязательна!")]
        public string Category { get; set; }
        [DisplayName("Подкатегория")]
        [Required(ErrorMessage ="Подкатегория обязательна!")]
        public string Subcategory { get; set; }
        [DisplayName("Количество")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество не может быть меньше 1, для этого воспользуйтесь удалением!")]
        public int Availability { get; set; }

        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
