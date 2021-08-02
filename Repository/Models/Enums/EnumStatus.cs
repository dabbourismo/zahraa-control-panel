﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Enums
{
    public enum EnumStatus
    {
        [Display(Name = "مفعل")]
        Active = 0,
        [Display(Name = "غير مفعل")]
        InActive = 1
    }
}
