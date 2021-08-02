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
    [System.Web.Http.RoutePrefix("api/RoomUser")]
    public class RoomUserController : ApiController
    {
        private readonly AppDbContext context;
        private HttpResponseMessage httpResponse;
        public RoomUserController()
        {
            context = new AppDbContext();
        }

        [Route("JoinRoom")]
        [HttpPost]
        public HttpResponseMessage JoinRoom([FromBody]RoomUser roomUser)
        {
            context.RoomUsers.Add(roomUser);
            context.SaveChanges();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }




        [HttpPost]
        [Route("DeleteRoomUser")]
        public HttpResponseMessage DeleteRoomUser(int userId, int roomId)
        {
            var roomUser = context.RoomUsers.Where(x => x.UserId == userId && x.RoomId == roomId).FirstOrDefault();

            context.RoomUsers.Remove(roomUser);
            context.SaveChanges();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
