using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public EnumGovernment Government { get; set; }

        public string Address { get; set; }

        public string SchoolName { get; set; }

        public EnumUserType UserType { get; set; }

        public string NationalId { get; set; }

        public int Balance { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public int? LevelId { get; set; }
        public Level Level { get; set; }

        public int? DivisionId { get; set; }
        public Division Division { get; set; }

        public EnumStatus Status { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

    }
}
