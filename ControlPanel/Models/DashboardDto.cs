using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Models
{
    public class DashboardDto
    {
        [Display(Name = "من")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public DateTime FromDate { get; set; } = DateTime.Now;

        [Display(Name = "الى")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public DateTime ToDate { get; set; } = DateTime.Now;



        [Display(Name = "اسم الكلية")]
        public List<SelectListItem> FacultyDropDownList { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }


        [Display(Name = "اسم المرحلة")]
        public List<SelectListItem> LevelDropDownList { get; set; }
        public int? LevelId { get; set; }
        public string LevelName { get; set; }


        [Display(Name = "اسم المادة")]
        public List<SelectListItem> MaterialDropDownList { get; set; }
        public int? MaterialId { get; set; }
        public string MaterialName { get; set; }




        public int RegisteredStudents { get; set; }
        public int Purchases { get; set; }
    }
}