using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class PaymentDetail

    {
        public int Id { get; set; }

        public DateTime PayDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Payed { get; set; }

        public EnumPaymentDirection Direction { get; set; }
    }
}
