using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public DateTime DateAdded { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; } 

        public decimal Price { get; set; }

        public bool Status { get; set; }
        public int Degree { get; set; } 
        public int NumberOfQuestions { get; set; }

        [NotMapped]
        public bool isBought { get; set; }
    }
}
