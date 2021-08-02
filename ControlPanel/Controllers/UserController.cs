using AutoMapper;
using AutoMapper.QueryableExtensions;
using ControlPanel.Models;
using ControlPanel.Services;
using Repository.GenericRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public UserController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult StudentIndex()
        {
            return View();
        }
        public ActionResult TrainerIndex()
        {
            return View();
        }

        public JsonResult ViewAllStudentUsers()
        {
            List<UserDto> UserDto = unitOfWork.UserRepo.GetAll()
                .Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student)
                .ProjectTo<UserDto>()
                .ToList();
            return Json(new { data = UserDto }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ViewAllTrainerUsers()
        {
            List<UserDto> UserDto = unitOfWork.UserRepo.GetAll()
                .Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Trainer)
                .ProjectTo<UserDto>()
                .ToList();
            return Json(new { data = UserDto }, JsonRequestBehavior.AllowGet);
        }
        #region student
        [HttpGet]
        public ActionResult AddEditStudentUser(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new UserDto()
                    {
                        FacultyDropDownList = dropdownLists.FacultyDropDownList(false),
                        LevelDropDownList = dropdownLists.LevelDropDownList(false),
                        DivisionDropDownList = dropdownLists.DivisionDropDownList(false),
                    });
                default:
     
                    var User = unitOfWork.UserRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<User, UserDto>(User);

                    dto.FacultyDropDownList = dropdownLists.FacultyDropDownList(false);
                    SelectListItem selecteditem
                        = dto.FacultyDropDownList.Find(e => e.Value == dto.FacultyId.ToString());
                    selecteditem.Selected = true;


                    dto.LevelDropDownList = dropdownLists.LevelDropDownList(false);
                    SelectListItem selecteditem2
                        = dto.LevelDropDownList.Find(e => e.Value == dto.LevelId.ToString());
                    selecteditem2.Selected = true;


                    dto.DivisionDropDownList = dropdownLists.DivisionDropDownList(false);
                    SelectListItem selecteditem3
                        = dto.DivisionDropDownList.Find(e => e.Value == dto.DivisionId.ToString());
                    selecteditem3.Selected = true;

                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditStudentUser(UserDto UserDto)
        {
            UserDto.UserType = Repository.Models.Enums.EnumUserType.Student;
            var User = Mapper.Map<UserDto, User>(UserDto);
            //add operation
            switch (UserDto.Id)
            {
                case 0:
                    unitOfWork.UserRepo.Insert(User);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة الطالب بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                   // ModelState.Remove("UserDto.Username");
                    unitOfWork.UserRepo.Update(User);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الطالب بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult DeleteStudentUser(int Id)
        {
            unitOfWork.UserRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الطالب بنجاح" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region trainer
        [HttpGet]
        public ActionResult AddEditTrainerUser(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new UserDto()
                    {
                        FacultyDropDownList = dropdownLists.FacultyDropDownList(false),
                        LevelDropDownList = dropdownLists.LevelDropDownList(false),
                        DivisionDropDownList = dropdownLists.DivisionDropDownList(false),
                    });
                default:
                    var User = unitOfWork.UserRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<User, UserDto>(User);

                    dto.FacultyDropDownList = dropdownLists.FacultyDropDownList(false);
                    SelectListItem selecteditem
                        = dto.FacultyDropDownList.Find(e => e.Value == dto.FacultyId.ToString());
                    selecteditem.Selected = true;


                    //dto.LevelDropDownList = dropdownLists.LevelDropDownList(false);
                    //SelectListItem selecteditem2
                    //    = dto.LevelDropDownList.Find(e => e.Value == dto.LevelId.ToString());
                    //selecteditem2.Selected = true;


                    //dto.DivisionDropDownList = dropdownLists.DivisionDropDownList(false);
                    //SelectListItem selecteditem3
                    //    = dto.DivisionDropDownList.Find(e => e.Value == dto.DivisionId.ToString());
                    //selecteditem3.Selected = true;

                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditTrainerUser(UserDto userDto)
        {
            userDto.UserType = Repository.Models.Enums.EnumUserType.Trainer;
            userDto.Balance = -1;
            var User = Mapper.Map<UserDto, User>(userDto);
            //add operation
            switch (userDto.Id)
            {
                case 0:
                    unitOfWork.UserRepo.Insert(User);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة المدرب بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.UserRepo.Update(User);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل المدرب بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult DeleteTrainerUser(int Id)
        {
            unitOfWork.UserRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف المدرب بنجاح" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        [HttpPost]
        public JsonResult ToggleUserActive(int Id)
        {
            var user = unitOfWork.UserRepo.GetOneBy(x => x.Id == Id);
            if (user.Status == Repository.Models.Enums.EnumStatus.Active)
            {
                user.Status = Repository.Models.Enums.EnumStatus.InActive;
            }
            else
            {
                user.Status = Repository.Models.Enums.EnumStatus.Active;
            }
            unitOfWork.Complete();

            return Json(new { success = true, message = "تم تغيير حالة المستخدم بنجاح" }, JsonRequestBehavior.AllowGet);
        }

   
       

    }
}