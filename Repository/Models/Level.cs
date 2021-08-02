using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Level
    {
        public int Id { get; set; }

        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }

        public string Name { get; set; }
    }
}
