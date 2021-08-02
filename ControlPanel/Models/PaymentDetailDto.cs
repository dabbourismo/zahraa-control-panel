using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlPanel.Models
{
    public class PaymentDetailDto
    {
        public int Id { get; set; }

        public DateTime PayDate { get; set; }

        public int UserId { get; set; }
        public string Username{ get; set; }

        public int Payed { get; set; }

        public EnumPaymentDirection Direction { get; set; }
    }
}