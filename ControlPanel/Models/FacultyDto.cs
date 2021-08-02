using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlPanel.Models
{
    public class FacultyDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم الكلية (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
    }
}