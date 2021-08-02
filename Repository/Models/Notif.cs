using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Notif
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public int? LevelId { get; set; }
        public Level Level { get; set; }

        public int? DivisionId { get; set; }
        public Division Division { get; set; }

    }
}
