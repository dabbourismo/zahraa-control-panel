using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class NotifDto
    {
        public int Id { get; set; }

        [Display(Name = "العنوان (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Title { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "اسم الكلية (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> FacultyDropDownList { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }

        [Display(Name = "اسم المرحلة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> LevelDropDownList { get; set; }
        public int? LevelId { get; set; }
        public string LevelName { get; set; }

        [Display(Name = "اسم القسم (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> DivisionDropDownList { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}