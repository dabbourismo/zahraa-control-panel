using Repository;
using Repository.ApiModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlPanel.APIControllers
{
    [System.Web.Http.RoutePrefix("api/Chat")]
    public class ChatController : ApiController
    {
        private readonly AppDbContext context;
        private HttpResponseMessage httpResponse;
        public ChatController()
        {
            context = new AppDbContext();
        }

        [Route("InsertChat")]
        public HttpResponseMessage InsertChat([FromBody]Chat chat)
        {
            chat.FromUserName = context.Users.Where(x => x.Id == chat.FromUserId).FirstOrDefault().Name.ToString();
            context.Chats.Add(chat);
            context.SaveChanges();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            List<RoomUser> roomUsers = context.RoomUsers.Where(x => x.RoomId == chat.RoomId).ToList();

            var chatStatues = new List<ChatStatue>();

            foreach (var user in roomUsers)
            {
                if (user.Id != chat.FromUserId)
                {
                    var chatStatue = new ChatStatue()
                    {
                        ChatId = chat.Id,
                        RoomId = chat.RoomId,
                        UserId = user.Id,
                        UserName = context.Users.Where(x => x.Id == user.Id).FirstOrDefault().Name,
                        MessageId = chat.Id,
                        isDelivered = false,
                        isRead = false
                    };
                    chatStatues.Add(chatStatue);
                }
            }
            context.ChatStatues.AddRange(chatStatues);
            context.SaveChanges();
            return response;
        }


        public HttpResponseMessage UpdateIsDelivered(int userId)
        {
            ChatStatue chatStatue = context.ChatStatues.Where(x => x.UserId == userId).FirstOrDefault();
            chatStatue.isDelivered = true;
            context.Entry(chatStatue).State = EntityState.Modified;
            context.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        public HttpResponseMessage UpdateIsRead(int userId, int roomId)
        {
            ChatStatue chatStatue = context.ChatStatues.Where(x => x.UserId == userId && x.RoomId == roomId).FirstOrDefault();
            chatStatue.isDelivered = true;
            context.Entry(chatStatue).State = EntityState.Modified;
            context.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }


        [Route("GetChat")]
        public IEnumerable<Chat> GetChat(int roomId)
        {
            List<Chat> chats = context.Chats.Where(x => x.RoomId == roomId).Include(x => x.ChatStatues).ToList();
            return chats;
        }

        [HttpGet]
        [Route("GetMessageStatue")]
        public IEnumerable<ChatStatue> GetMessageStatue(int chatId)
        {
            List<ChatStatue> chatStatue = context.ChatStatues
               .Where(x => x.ChatId == chatId).ToList();
            return chatStatue;
        }


        [Route("GetUnDeliveredChat")]
        public IEnumerable<ChatStatue> GetUnDeliveredChat(int userId)
        {
            List<ChatStatue> chatStatue = context.ChatStatues
                .Include(x => x.Chat)
                .Where(x => x.UserId == userId && x.isDelivered == false).ToList();
            return chatStatue;
        }


    }
}
