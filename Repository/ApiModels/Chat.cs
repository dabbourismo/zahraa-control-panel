using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ApiModels
{
    public class Chat
    {
        public int Id { get; set; }

        public int FromUserId { get; set; }

        public string FromUserName { get; set; }

        public int RoomId { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm"));

        public List<ChatStatue> ChatStatues { get; set; } = new List<ChatStatue>();

    }
}
