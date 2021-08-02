using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlPanel.Models
{
    public class PaymentDto
    {
        public int Payed { get; set; }

        public string UserName { get; set; }

        public EnumProductType ProductType { get; set; }

        public string BuyedItemName { get; set; }

        public DateTime BuyDate { get; set; }
    }
}