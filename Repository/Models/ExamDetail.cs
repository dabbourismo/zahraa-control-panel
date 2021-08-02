using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class ExamDetail
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public string Question { get; set; }
        public string Image { get; set; }


        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }

        public int RightAnswer { get; set; }
        public int QuestionTimer { get; set; }
    }
}
