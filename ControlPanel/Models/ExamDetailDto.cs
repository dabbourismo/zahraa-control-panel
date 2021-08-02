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
    public class ExamDetailDto
    {

        public int Id { get; set; }

        [Display(Name = "اسم الاختبار")]
        public List<SelectListItem> ExamsDropDownList { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نص السؤال")]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }

        [Required(ErrorMessage = "اختر صورة لرفعها")]
        [Display(Name = "صورة (اختياري)")]
        public string Image { get; set; }

        [Display(Name = "الصورة")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [NotMapped]
        public string Link { get; set; } = Paths.ExamDetailPath;

        public int SelectedAnswer { get; set; }

        [Display(Name = "الاجابة 1")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Answer1 { get; set; }

        [Display(Name = "الاجابة 2")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Answer2 { get; set; }

        [Display(Name = "الاجابة 3")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Answer3 { get; set; }

        [Display(Name = "الاجابة 4")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Answer4 { get; set; }

        [Display(Name = "الاجابة 5 (اختياري)")]
        public string Answer5 { get; set; }


        [Display(Name = "الاجابة الصحيحة هي :")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> RightAnswerDropDownList { get; set; }
        public int RightAnswer { get; set; }

        [Display(Name = "مدة الاجابة (بالثواني)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(1, 10000, ErrorMessage = "يجب ان تكون القيمة من 1 الى 10000")]
        public int QuestionTimer { get; set; } = 60;
     
    }
}