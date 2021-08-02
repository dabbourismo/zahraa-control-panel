using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم المستخدم (مطلوب)")]
        [Remote("CheckUserNameDublicate", "Validation",
            HttpMethod = "GET", ErrorMessage = "اسم المستخدم موجود مسبقا",
            AdditionalFields = "PreviousUsername")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ادخل كلمة المرور")]
        [StringLength(16, ErrorMessage = "يجب ان يكون الباسوورد من 8 الى 16 حرف", MinimumLength = 8)]
        [Display(Name = "كلمة المرور (مطلوب)")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "تأكيد كلمة المرور")]
        //[StringLength(16, ErrorMessage = "يجب ان يكون الباسوورد من 8 الى 16 حرف", MinimumLength = 8)]
        //[Display(Name = "تأكيد كلمة المرور")]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "الباسوورد غير متطابق")]
        //public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الاسم (مطلوب)")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم المحمول الاول (مطلوب)")]
        [RegularExpression(@"(01)[0-9]{9}", ErrorMessage = "رقم الهاتف غير صحيح")]
        public string Phone1 { get; set; }

        [Display(Name = "رقم المحمول الثاني")]
        [RegularExpression(@"(01)[0-9]{9}", ErrorMessage = "رقم الهاتف غير صحيح")]
        public string Phone2 { get; set; }

        [Display(Name = "المحافظة")]
        public EnumGovernment Government { get; set; } = EnumGovernment.Alex;

        [Display(Name = "العنوان")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "اسم المدرسة")]
        public string SchoolName { get; set; }

        [Display(Name = "نوع المستخدم")]
        public EnumUserType UserType { get; set; }

        [Display(Name = "رقم البطاقة (مطلوب)")]
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        [RegularExpression(@"(2|3)[0-9][1-9][0-1][1-9][0-3][1-9](01|02|03|04|11|12|13|14|15|16|17|18|19|21|22|23|24|25|26|27|28|29|31|32|33|34|35|88)\d\d\d\d\d", ErrorMessage = "رقم البطاقة غير صحيح")]
        public string NationalId { get; set; }

        [Display(Name = "الرصيد")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, int.MaxValue, ErrorMessage = "اختر المبلغ")]
        public int Balance { get; set; } = 0;

        [Display(Name = "اسم الكلية (مطلوب)")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public List<SelectListItem> FacultyDropDownList { get; set; }
        public int FacultyId { get; set; }
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

        [Display(Name = "الحالة")]
        public EnumStatus Status { get; set; } = EnumStatus.Active;


        public DateTime RegisterDate { get; set; }

    }
}