using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Lecture
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public int Price { get; set; }

        [NotMapped]
        public bool isBought { get; set; }

    }
}
