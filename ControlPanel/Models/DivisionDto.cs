using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class DivisionDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم المرحلة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> LevelDropDownList { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }

        [Display(Name = "اسم القسم (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

    }
}