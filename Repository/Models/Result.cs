using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
   public class Result
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int UserResult { get; set; }
        public int TotalDegree { get; set; }
    }
}
