using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class ExamDto
    {
        public int Id { get; set; }
        [Display(Name = "اسم الاختبار (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string ExamName { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; } = DateTime.Now;


        [Display(Name = "اسم الدكتور (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> UserDropDownList { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        [Display(Name = "اسم المادة (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> MaterialDropDownList { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }

        [Display(Name = "السعر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 1000000, ErrorMessage = "يجب ان تكون القيمة صفر او اكبر")]
        public decimal Price { get; set; } = 0;

        [Display(Name = "مفعل؟")]
        public bool Status { get; set; } = true;

        [Display(Name = "الدرجة الكلية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, 1000000, ErrorMessage = "يجب ان تكون القيمة صفر او اكبر")]
        public int Degree { get; set; }

        [Display(Name = "عدد الاسئله التي ستظهر للطالب")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(1, 1000000, ErrorMessage = "يجب ان تكون القيمة اكبر من صفر")]
        public int NumberOfQuestions { get; set; }
    }
}