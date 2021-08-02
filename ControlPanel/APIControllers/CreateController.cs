using Repository;
using Repository.Models;
using Repository.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlPanel.APIControllers
{
    [RoutePrefix("api/create")]
    public class CreateController : ApiController
    {
        private readonly AppDbContext context;
        private HttpResponseMessage httpResponse;

        public CreateController()
        {
            context = new AppDbContext();
        }

        [HttpPost]
        [Route("ResultAdd")]
        public HttpResponseMessage ResultAdd([FromBody] Result result)
        {
            context.Results.Add(result);
            context.SaveChanges();
            httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            return httpResponse;
        }

        [HttpPost]
        [Route("CreateUser")]
        public HttpResponseMessage CreateUser([FromBody] User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            return httpResponse;
        }



        [HttpPost]
        [Route("PaymentAdd")]
        public HttpResponseMessage PaymentAdd([FromBody] Payment payment)
        {
            int itemPrice = 0;
            var user = context.Users.Find(payment.UserId);
            int itemId = payment.BuyedItemId;
            string itemName = "";           
            switch ((int)payment.ProductType)
            {
                case 0:
                    itemPrice = context.Lectures.Find(itemId).Price;
                    itemName = context.Lectures.Find(itemId).Name;
                    break;
                case 1:
                    itemPrice = context.Lives.Find(itemId).Price;
                    itemName = context.Lives.Find(itemId).Name;
                    break;
                case 2:
                    itemPrice = Convert.ToInt32(context.Exams.Find(itemId).Price);
                    itemName = context.Exams.Find(itemId).ExamName;
                    break;
                //case 3:
                //    itemPrice = context.Lectures.Find(itemId).Price;
                //    break;
                default:
                    break;
            }

            if (user.Balance < itemPrice)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            user.Balance = user.Balance - itemPrice;
            var paymentOp = new Payment()
            {
                Payed = itemPrice,
                BuyedItemId = itemId,
                ProductType = payment.ProductType,
                UserId = user.Id,
                BuyDate = DateTime.Now,
                TrainerId = payment.TrainerId,
                Name = itemName
            };
            context.Payments.Add(paymentOp);
            context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }



        [HttpPost]
        [Route("PaymentCheck")]
        public HttpResponseMessage PaymentCheck(int userId, int productType, int buyedItemId)
        {
            var payment = context.Payments.Where(x => x.UserId == userId
            && x.ProductType == (EnumProductType)productType
            && x.BuyedItemId == buyedItemId)
            .FirstOrDefault();

            if ((DateTime.Now - payment.BuyDate).Days > 1)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            return httpResponse;
        }


        [HttpPost]
        [Route("UserUpdate")]
        public HttpResponseMessage UserUpdate([FromBody] User user)
        {
            var oldUser = context.Users.Find(user.Id);

            oldUser.Name = user.Name;
            oldUser.Phone1 = user.Phone1;
            oldUser.Phone2 = user.Phone2;
            oldUser.Address = user.Address;
            oldUser.SchoolName = user.SchoolName;
            oldUser.FacultyId = user.FacultyId;
            oldUser.LevelId = user.LevelId;
            oldUser.DivisionId = user.DivisionId;

            context.SaveChanges();
            httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            return httpResponse;
        }
    }
}
