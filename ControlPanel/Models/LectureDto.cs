using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class LectureDto
    {
        public int Id { get; set; }

        [Display(Name = "اسم المدرب (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> TrainerDropDownList { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }


        [Display(Name = "اسم المادة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> MaterialDropDownList { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }


        [Display(Name = "اسم المحاضرة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        [Display(Name = "التاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "فضلا اختر التاريخ")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime Date { get; set; } = DateTime.Now;


        [Display(Name = "اللينك (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Url { get; set; }

        [Display(Name = "السعر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 10000, ErrorMessage = "يجب ان تكون القيمة اكبر من 0")]
        public int Price { get; set; }
    }
}