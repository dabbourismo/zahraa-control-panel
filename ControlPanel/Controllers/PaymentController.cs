using AutoMapper;
using AutoMapper.QueryableExtensions;
using ControlPanel.Models;
using ControlPanel.Services;
using Repository.GenericRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public PaymentController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentDetailsIndex()
        {
            return View();
        }

        public JsonResult ViewAllPayments()
        {
            List<Payment> payment = unitOfWork.PaymentRepo.GetAll().Include(x => x.User).ToList();
            var paymentDtos = new List<PaymentDto>();
            foreach (var item in payment)
            {
                var paymentDto = new PaymentDto()
                {
                    UserName = item.User.Name,
                    ProductType = item.ProductType,
                    BuyedItemName = item.BuyedItemId.ToString(), // to be resolved
                    BuyDate = item.BuyDate
                };
                paymentDtos.Add(paymentDto);
            }
            return Json(new { data = paymentDtos }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ViewAllPaymentDetails()
        {
            List<PaymentDetail> payments = unitOfWork.PaymentDetailRepo.GetAll().Include(x => x.User).ToList();
            var paymentDetailDto = new List<PaymentDetailDto>();

            var dtos = Mapper.Map<List<PaymentDetail>, List<PaymentDetailDto>>(payments);

            return Json(new { data = dtos }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddBalance(int id = 0)
        {
            var student = unitOfWork.UserRepo.GetOneBy(x => x.Id == id);
            var balance = new BalanceDto()
            {
                OldBalance = student.Balance,
                AddedBalance = 0,
                RemainingBalance = student.Balance,
                UserId = student.Id
            };

            return View(balance);

        }
        [HttpPost]
        public ActionResult AddBalance(BalanceDto dto)
        {
            var student = unitOfWork.UserRepo.GetOneBy(x => x.Id == dto.UserId);
            student.Balance = student.Balance + dto.AddedBalance;
            var paymentDetail = new PaymentDetail()
            {
                Direction = Repository.Models.Enums.EnumPaymentDirection.Income,
                PayDate = DateTime.Now,
                Payed = dto.AddedBalance,
                UserId = student.Id
            };
            unitOfWork.PaymentDetailRepo.Insert(paymentDetail);
            unitOfWork.Complete();
            string message = $@"تم اضافة رصيد {dto.AddedBalance} جنية
                                للطالب {student.Name}
                                رصيدة الحالي {student.Balance} جنية";
            return Json(new { success = true, message = message }, JsonRequestBehavior.AllowGet);

        }




        [HttpGet]
        public ActionResult TakeBalance(int id = 0)
        {
            var student = unitOfWork.UserRepo.GetOneBy(x => x.Id == id);
            var balance = new BalanceDto()
            {
                OldBalance = student.Balance,
                AddedBalance = 0,
                RemainingBalance = student.Balance,
                UserId = student.Id
            };

            return View(balance);

        }
        [HttpPost]
        public ActionResult TakeBalance(BalanceDto dto)
        {
            var student = unitOfWork.UserRepo.GetOneBy(x => x.Id == dto.UserId);
            student.Balance = student.Balance - dto.AddedBalance;
            var paymentDetail = new PaymentDetail()
            {
                Direction = Repository.Models.Enums.EnumPaymentDirection.Outcome,
                PayDate = DateTime.Now,
                Payed = dto.AddedBalance,
                UserId = student.Id
            };
            unitOfWork.PaymentDetailRepo.Insert(paymentDetail);
            unitOfWork.Complete();
            string message = $@"تم استرداد رصيد {dto.AddedBalance} جنية
                                من الطالب {student.Name}
                                رصيدة الحالي {student.Balance} جنية";
            return Json(new { success = true, message = message }, JsonRequestBehavior.AllowGet);

        }


    }
}