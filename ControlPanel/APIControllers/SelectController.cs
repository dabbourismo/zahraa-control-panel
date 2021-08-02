using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlPanel.APIControllers
{
    [RoutePrefix("api/select")]
    public class SelectController : ApiController
    {
        private readonly AppDbContext context;
        private HttpResponseMessage httpResponse;

        public SelectController()
        {
            context = new AppDbContext();
        }

        [HttpGet]
        [Route("NewsGetAll")]
        public IEnumerable<News> NewsGetAll()
        {
            var items = context.News
                               .OrderByDescending(x => x.Date)
                               .ToList();
            return items;
        }

        [HttpGet]
        [Route("HomeworkGetLastTen")]
        public IEnumerable<Homework> HomeworkGetLastTen(int levelId,int divisionId,int userId)
        {

            var materals = context.Materials.Where(x => x.LevelId == levelId && x.DivisionId == divisionId).ToList();
            var lectures = new List<Homework>();
            foreach (var material in materals)
            {
                var todayLectures = context.Homeworks.Where(x => x.MaterialId == material.Id).Include(x => x.User).ToList();
                lectures.AddRange(todayLectures);
            }

            var tenLecs = lectures.OrderByDescending(x => x.Date).Take(10);
            foreach (var lecture in tenLecs)
            {
                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.File && x.BuyedItemId == lecture.Id)
                .OrderByDescending(x => x.BuyDate).FirstOrDefault();

                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    lecture.isBought = false;

                }
                else
                {
                    lecture.isBought = true;
                }
            }


            return tenLecs;
        }

        [HttpGet]
        [Route("HomeworkGetAll")]
        public IEnumerable<Homework> HomeworkGetAll(int materialId, int trainerId,int userId)
        {
            var items = new List<Homework>();
            if (materialId != 0 && trainerId != 0)
            {
                items = context.Homeworks
                               .Where(x => x.MaterialId == materialId && x.UserId == trainerId)
                               .Include(x => x.Material)
                               .Include(x => x.User)
                               .ToList();
               
            }
            if (materialId != 0)
            {
                items = context.Homeworks
                               .Where(x => x.MaterialId == materialId)
                               .Include(x => x.Material)
                               .Include(x => x.User)
                               .ToList();
            }
            if (trainerId != 0)
            {
                items = context.Homeworks
                               .Where(x => x.UserId == trainerId)
                               .Include(x => x.Material)
                               .Include(x => x.User)
                               .ToList();
            }


            foreach (var exam in items)
            {
                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.File && x.BuyedItemId == exam.Id)
                .OrderByDescending(x => x.BuyDate).FirstOrDefault();
                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    exam.isBought = false;
                }
                else
                {
                    exam.isBought = true;
                }
            }
            return items;
        }

        [HttpGet]
        [Route("ExamDetailGetById")]
        public IEnumerable<ExamDetail> ExamDetailGetById(int examId)
        {
            var items = context.ExamDetails.Where(x => x.ExamId == examId)
                .ToList();
            return items;
        }

        [HttpGet]
        [Route("ExamsGetAll")]
        public IEnumerable<Exam> ExamsGetAll(int materialId, int userId)
        {
            var items = context.Exams.Where(x => x.MaterialId == materialId)
                .Include(x => x.Material)
                .Include(x => x.User)
                .ToList();


            foreach (var exam in items)
            {
                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.Exam && x.BuyedItemId == exam.Id)
                .OrderByDescending(x => x.BuyDate).FirstOrDefault();
                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    exam.isBought = false;
                }
                else
                {
                    exam.isBought = true;
                }
            }
            return items;
        }


        [HttpGet]
        [Route("FacultyGetAll")]
        public IEnumerable<Faculty> FacultyGetAll()
        {
            var items = context.Facultys.ToList();
            return items;
        }


        [HttpGet]
        [Route("LevelsGetAll")]
        public IEnumerable<Level> LevelsGetAll(int facultyId)
        {
            var items = context.Levels
                .Where(x => x.FacultyId == facultyId)
                .Include(x => x.Faculty)
                .ToList();
            return items;
        }



        [HttpGet]
        [Route("DivisionsGetAll")]
        public IEnumerable<Division> DivisionsGetAll(int levelId)
        {
            var items = context.Divisions
                .Where(x => x.LevelId == levelId)
                .Include(x => x.Level)
                .Include(x => x.Level.Faculty)
                .ToList();
            return items;
        }

        [HttpGet]
        [Route("MaterialsGetAll")]
        public IEnumerable<Material> MaterialsGetAll(int? levelId, int? divisionId)
        {
            var items = context.Materials
                .Where(x => (x.DivisionId == null || x.DivisionId == divisionId) && x.LevelId == levelId)
                .Include(x => x.Division)
                .Include(x => x.Level)
                .Include(x => x.Level.Faculty)
                .ToList();
            return items;
        }

        [HttpGet]
        [Route("Login")]
        public User Login(string username, string password)
        {
            var item = context.Users.FirstOrDefault(x => (x.Username == username || x.NationalId == username) && x.Password == password);
            if (item != null)
            {
                return item;
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        [Route("TrainersGetAll")]
        public IEnumerable<User> TrainersGetAll(int facultyId)
        {
            var items = context.Users
                .Where(x => x.FacultyId == facultyId && x.UserType == Repository.Models.Enums.EnumUserType.Trainer)
                .Include(x => x.Division)
                .Include(x => x.Level)
                .Include(x => x.Faculty)
                .ToList();
            return items;
        }


        [HttpGet]
        [Route("LiveGetAll")]
        public IEnumerable<Live> LiveGetAll(int? materialId, int? trainerId, int userId)
        {
            List<Live> items = new List<Live>();
            if (trainerId == 0 && materialId == 0)
            {
                items = context.Lives
                   .Include(x => x.User)
                   .Include(x => x.Material)
                   .ToList();
            }
            else if (trainerId == 0)
            {
                items = context.Lives
                 .Where(x => x.MaterialId == materialId)
                 .Include(x => x.User)
                 .Include(x => x.Material)
                 .ToList();
            }
            else if (materialId == 0)
            {
                items = context.Lives
                 .Where(x => x.UserId == trainerId)
                 .Include(x => x.User)
                 .Include(x => x.Material)
                 .ToList();
            }
            else
            {
                items = context.Lives
                      .Where(x => x.MaterialId == materialId && x.UserId == trainerId)
                      .Include(x => x.User)
                      .Include(x => x.Material)
                      .ToList();
            }

            foreach (var live in items)
            {
                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.Live && x.BuyedItemId == live.Id)
                .OrderByDescending(x => x.BuyDate).FirstOrDefault();
                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    live.isBought = false;

                }
                else
                {
                    live.isBought = true;
                }
            }
            return items;

        }


        [HttpGet]
        [Route("LectureGetAll")]
        public IEnumerable<Lecture> LectureGetAll(int? materialId, int? trainerId, int userId)
        {
            List<Lecture> items = new List<Lecture>();
            if (trainerId == 0 && materialId == 0)
            {
                items = context.Lectures
                   .Include(x => x.User)
                   .Include(x => x.Material)
                   .ToList();
            }
            else if (trainerId == 0)
            {
                items = context.Lectures
                 .Where(x => x.MaterialId == materialId)
                 .Include(x => x.User)
                 .Include(x => x.Material)
                 .ToList();
            }
            else if (materialId == 0)
            {
                items = context.Lectures
                 .Where(x => x.UserId == trainerId)
                 .Include(x => x.User)
                 .Include(x => x.Material)
                 .ToList();
            }
            else
            {
                items = context.Lectures
                      .Where(x => x.MaterialId == materialId && x.UserId == trainerId)
                      .Include(x => x.User)
                      .Include(x => x.Material)
                      .ToList();
            }

            foreach (var lecture in items)
            {

                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.Lecture && x.BuyedItemId == lecture.Id)
                .OrderByDescending(x => x.BuyDate)
                .FirstOrDefault();
                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    lecture.isBought = false;

                }
                else
                {
                    lecture.isBought = true;
                }
            }
            return items;

        }

        [HttpGet]
        [Route("NotifsGetAll")]
        public IEnumerable<Notif> NotifsGetAll(int? facultyId, int? levelId, int? divisionId)
        {
            var items = context.Notifs
                .Where(x => ((x.FacultyId == null)
                        || ((x.FacultyId == facultyId) && (x.LevelId == null))
                        || ((x.FacultyId == facultyId) && (x.LevelId == levelId) && (x.DivisionId == null))
                        || ((x.FacultyId == facultyId) && (x.LevelId == levelId) && (x.DivisionId == divisionId))))
                        .ToList();
            return items;
        }



        [HttpGet]
        [Route("PaymentsGetAll")]
        public IEnumerable<Payment> PaymentsGetAll(int userId)
        {
            var items = context.Payments
               .Where(x => x.UserId == userId)
                .ToList();
            return items;
        }


        [HttpGet]
        [Route("UserGetBalance")]
        public int UserGetBalance(int userId)
        {
            var item = context.Users.Find(userId).Balance;
            return item;
        }


        [HttpGet]
        [Route("LiveGetToday")]
        public IEnumerable<Live> LiveGetToday(int levelId, int divisionId, int userId)
        {
            var materals = context.Materials.Where(x => x.LevelId == levelId && x.DivisionId == divisionId).ToList();
            DateTime today = DateTime.UtcNow.Date.AddHours(2);
            var lives = new List<Live>();
            foreach (var material in materals)
            {
                var Todatlives = context.Lives.Where(x => x.MaterialId == material.Id
                && x.Date.Year == today.Year && x.Date.Month == today.Month && x.Date.Day == today.Day).Include(x => x.User).ToList();
                lives.AddRange(Todatlives);
            }

            foreach (var live in lives)
            {
                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.Live && x.BuyedItemId == live.Id)
                .OrderByDescending(x => x.BuyDate).FirstOrDefault();

                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    live.isBought = false;

                }
                else
                {
                    live.isBought = true;
                }
            }


            return lives;
        }


        [HttpGet]
        [Route("LectureGetLastTen")]
        public IEnumerable<Lecture> LectureGetLastTen(int userId, int? levelId, int divisionId)
        {


            var materals = context.Materials.Where(x => x.LevelId == levelId && x.DivisionId == divisionId).ToList();
            var lectures = new List<Lecture>();
            foreach (var material in materals)
            {
                var todayLectures = context.Lectures.Where(x => x.MaterialId == material.Id).Include(x => x.User).ToList();
                lectures.AddRange(todayLectures);
            }

            var tenLecs = lectures.OrderByDescending(x => x.Date).Take(10);
            foreach (var lecture in tenLecs)
            {
                var payment = context.Payments.Where(x => x.UserId == userId
                && x.ProductType == Repository.Models.Enums.EnumProductType.Lecture && x.BuyedItemId == lecture.Id)
                .OrderByDescending(x => x.BuyDate).FirstOrDefault();

                if (payment == null || (DateTime.Now - payment.BuyDate).Days >= 1)
                {
                    lecture.isBought = false;

                }
                else
                {
                    lecture.isBought = true;
                }
            }


            return tenLecs;
        }



        [HttpGet]
        [Route("UserGetInfo")]
        public User UserGetInfo(int userId)
        {
            var item = context.Users.Where(x => x.Id == userId)
                .Include(x => x.Faculty)
                .Include(x => x.Level)
                .Include(x => x.Division).FirstOrDefault();
            return item;
        }


        [HttpGet]
        [Route("LiveGetTrainers")]
        public IEnumerable<User> LiveGetTrainers(int materialId)
        {
            var lives = context.Lives.Where(x => x.MaterialId == materialId).ToList();
            var trainers = new List<User>();
            foreach (var item in lives)
            {
                var trainer = context.Users.Where(x => x.Id == item.UserId)
                     .Include(x => x.Faculty)
                .Include(x => x.Level)
                .Include(x => x.Division).FirstOrDefault();
                trainers.Add(trainer);
            }
            var goodTrainers = trainers.Distinct();
            return goodTrainers;
        }
        [HttpGet]
        [Route("LectureGetTrainers")]
        public IEnumerable<User> LectureGetTrainers(int materialId)
        {
            var Lectures = context.Lectures.Where(x => x.MaterialId == materialId).ToList();
            var trainers = new List<User>();
            foreach (var item in Lectures)
            {
                var trainer = context.Users.Where(x => x.Id == item.UserId).Include(x => x.Faculty)
                .Include(x => x.Level)
                .Include(x => x.Division).FirstOrDefault();
                trainers.Add(trainer);
            }
            var goodTrainers = trainers.Distinct();
            return goodTrainers;
        }


        [HttpGet]
        [Route("PaymentDetailGet")]
        public IEnumerable<PaymentDetail> PaymentDetailGet(int userId)
        {
            var items = context.PaymentDetails
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
                .OrderByDescending(x => x.PayDate)
                .ToList();
            return items;
        }
    }
}
