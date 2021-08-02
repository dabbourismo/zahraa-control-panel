using Repository;
using Repository.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlPanel.APIControllers
{
    [RoutePrefix("api/Room")]
    public class RoomController : ApiController
    {
        private readonly AppDbContext context;
        private HttpResponseMessage httpResponse;

        public RoomController()
        {
            context = new AppDbContext();
        }

        [Route("CreateRoom")]
        public HttpResponseMessage CreateRoom([FromBody]Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [Route("GetCreatedRooms")]
        [HttpGet]
        public List<Room> GetCreatedRooms(int hostUserId)
        {
            var rooms = context.Rooms.Where(x => x.HostUserId == hostUserId).ToList();
            foreach (var room in rooms)
            {
                room.UnReadMessages = context.ChatStatues.Where(x => x.UserId == hostUserId && x.RoomId == room.Id && x.isRead == false).Count();
            }
            return rooms;
        }

        [Route("GetSubscribedRooms")]
        [HttpGet]
        public List<Room> GetSubscribedRooms(int hostUserId)
        {

            List<RoomUser> roomUsers = context.RoomUsers.Where(x => x.UserId == hostUserId).ToList();

            var subRooms = new List<Room>();

            foreach (var subscripedRoom in roomUsers)
            {
                try
                {
                    Room room = new Room();
                    room = context.Rooms.Where(x => x.Id == subscripedRoom.RoomId).FirstOrDefault();

                    room.NumberOfMembers = context.RoomUsers.Where(x => x.RoomId == room.Id).Count();

                    int UnReadMessages;
                    try
                    {
                        UnReadMessages = context.ChatStatues.Where(x => x.UserId == hostUserId && x.RoomId == subscripedRoom.RoomId && x.isRead == false).Count();
                        room.UnReadMessages = UnReadMessages;
                    }
                    catch (Exception)
                    {
                        room.UnReadMessages = 0;
                    }


                    subRooms.Add(room);
                }
                catch { }

            }


            return subRooms;
        }


        [Route("GetAllRoomsExceptCreated")]
        public List<Room> GetAllRoomsExceptCreated(int hostUserId,int levelId)
        {
            List<Room> rooms = context.Rooms.Where(x => x.HostUserId != hostUserId && x.LevelId == levelId).ToList();
           // var user = context.Users.Find(hostUserId);
            foreach (var room in rooms)
            {
                room.NumberOfMembers = context.RoomUsers.Where(x => x.RoomId == room.Id).Count();
               // room.UserLevel = context.Levels.FirstOrDefault(x => x.Id == user.Id).Name;
            }

            return rooms;
        }

        [HttpGet]
        [Route("SearchRooms")]
        public List<Room> SearchRooms(string roomName, int hostUserId)
        {
            var rooms = context.Rooms.Where(x => x.RoomName.Contains(roomName)
            && x.HostUserId != hostUserId).ToList();

            return rooms;
        }

        [System.Web.Http.HttpPost]
        [Route("UpdateZoomUserPass")]
        public HttpResponseMessage UpdateZoomUserPass(int roomId, string zoomUser, string zoomPass)
        {
            var room = context.Rooms.Find(roomId);
            room.ZoomUser = zoomUser;
            room.ZoomPassword = zoomPass;
            context.SaveChanges();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }


        [HttpGet]
        [Route("RoomDelete")]
        public HttpResponseMessage RoomDelete(int roomId)
        {
            var rooms = context.Rooms.Find(roomId);
            context.Rooms.Remove(rooms);
            context.SaveChanges();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }
    }
}
