using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlPanel.Models
{
    public class BalanceDto
    {
        public int UserId { get; set; }
        [ReadOnly(true)]
        [DisplayName("الرصيد الاساسي")]
        public int OldBalance { get; set; }

        [DisplayName("الرصيد المضاف او المسترد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "هذا الحقل مطلوب")]
        [Range(1, 100000, ErrorMessage = "يجب ان يكون الرقم بواحد او اكثر")]
        public int AddedBalance { get; set; } = 0;

        [ReadOnly(true)]
        [DisplayName("الرصيد الجديد")]
        public int RemainingBalance { get; set; }
    }
}