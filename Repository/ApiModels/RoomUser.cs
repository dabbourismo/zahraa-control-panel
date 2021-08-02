using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ApiModels
{
    public class RoomUser
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int UserId { get; set; }

    }
}
