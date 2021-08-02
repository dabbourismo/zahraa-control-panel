using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Payed { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public EnumProductType ProductType { get; set; }

        public int BuyedItemId { get; set; }

        public DateTime BuyDate { get; set; }

        public int TrainerId { get; set; } = 0;

    }
}
