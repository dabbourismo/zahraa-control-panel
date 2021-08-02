using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class NewsDto
    {
        public int Id { get; set; }

        [Display(Name = "عنوان الخبر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Title { get; set; }


        [Display(Name = "الكلية")]
        public List<SelectListItem> FacultyDropDownList { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


        [Display(Name = "تفاصيل الخبر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Details { get; set; }
    }
}