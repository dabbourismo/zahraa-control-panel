using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Material
    {
        public int Id { get; set; }

        public Level Level { get; set; }
        public int LevelId { get; set; }

        public Division Division { get; set; }
        public int? DivisionId { get; set; }

        public string Name { get; set; }

    }
}
