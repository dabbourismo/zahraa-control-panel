using ControlPanel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class HomeworkDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم الواجب")]
        public string Name { get; set; }

        [Display(Name = "المادة")]
        public List<SelectListItem> MaterialsDropDownList { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }


        public int UserId { get; set; }

        [Display(Name = "التاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;


        [Display(Name = "السعر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 1000000, ErrorMessage = "يجب ان تكون القيمة بصفر او اكثر")]
        public decimal Price { get; set; }

        [Display(Name = "الملف (pdf,docx,docm,dotx,dotm,docb)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DataType(DataType.Upload)]
      //  [AllowExtensions(Extensions = "pdf,docx,docm,dotx,dotm,docb", ErrorMessage = "يجب ان يكون الملف وورد او PDF")]
        [NotMapped]
        public HttpPostedFileBase HomeworkFile { get; set; }

        public string Link { get; set; } = Paths.HomeworkPath;

        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public bool isValid { get; set; }
    }
}