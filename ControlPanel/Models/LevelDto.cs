using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class LevelDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم الكلية (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> FacultyDropDownList { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        [Display(Name = "اسم المرحلة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
    }
}