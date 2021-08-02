using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ApiModels
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomName { get; set; }

        public int LevelId { get; set; }
        public Level Level{ get; set; }

        public int HostUserId { get; set; }

        public string ZoomUser { get; set; }

        public string ZoomPassword { get; set; }

        [NotMapped]
        public int UnReadMessages { get; set; }

        [NotMapped]
        public int NumberOfMembers { get; set; }

        


    }
}
