using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ApiModels
{
    public class ChatStatue
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int RoomId { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }

        public bool isDelivered { get; set; }

        public bool isRead { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }

    }
}
