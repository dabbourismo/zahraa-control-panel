using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class LiveDto
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

        [Display(Name = "اسم الميتينج (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        [Display(Name = "التاريخ")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "فضلا اختر التاريخ")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "الوقت")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}", NullDisplayText = "فضلا اختر الوقت")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime Time { get; set; } = DateTime.Now;

        [Display(Name = "محتوى اللايف")]
        public string Comment { get; set; }

        [Display(Name = "Zoom meeting ID")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string ZoomMeetingId { get; set; }

        [Display(Name = "Zoom meeting Password")]
        public string ZoomPassword { get; set; }

        [Display(Name = "السعر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 10000, ErrorMessage = "يجب ان تكون القيمة اكبر من 0")]
        public int Price { get; set; }
    }
}