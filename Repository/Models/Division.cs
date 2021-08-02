using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Division
    {
        public int Id { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public string Name { get; set; }

    }
}
