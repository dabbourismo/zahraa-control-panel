using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public DateTime Date { get; set; }

        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
