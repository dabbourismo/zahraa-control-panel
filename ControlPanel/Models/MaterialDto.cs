using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class MaterialDto
    {
        public int Id { get; set; }
        [Display(Name = "اسم الفرقة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> LevelDropDownList { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }

        [Display(Name = "اسم القسم (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> DivisionDropDownList { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }

        [Display(Name = "اسم المادة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
    }
}