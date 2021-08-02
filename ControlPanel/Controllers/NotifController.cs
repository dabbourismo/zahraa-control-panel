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
    public class NotifController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public NotifController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllNotifs()
        {
            List<NotifDto> NotifDto = unitOfWork.NotifRepo.GetAll().ProjectTo<NotifDto>().ToList();
            return Json(new { data = NotifDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditNotif(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new NotifDto()
                    {
                        FacultyDropDownList = dropdownLists.FacultyDropDownList(true),
                        LevelDropDownList = dropdownLists.LevelDropDownList(true),
                        DivisionDropDownList = dropdownLists.DivisionDropDownList(true),
                    });
                default:
                    var Notif = unitOfWork.NotifRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Notif, NotifDto>(Notif);
                    dto.FacultyDropDownList = dropdownLists.FacultyDropDownList(true);
                    dto.LevelDropDownList = dropdownLists.LevelDropDownList(true);
                    dto.DivisionDropDownList = dropdownLists.DivisionDropDownList(true);
                    #region dropDownLists
                    if (dto.FacultyId != null)
                    {
                     
                        SelectListItem selecteditem1
                            = dto.FacultyDropDownList.Find(e => e.Value == dto.FacultyId.ToString());
                        selecteditem1.Selected = true;
                    }
                    else
                    {
                        SelectListItem selecteditem2
                                 = dto.FacultyDropDownList.Find(e => e.Value == null);
                        selecteditem2.Selected = true;
                    }



                    if (dto.LevelId != null)
                    {
                   
                        SelectListItem selecteditem3
                            = dto.LevelDropDownList.Find(e => e.Value == dto.LevelId.ToString());
                        selecteditem3.Selected = true;
                    }
                    else
                    {
                        SelectListItem selecteditem2
                                 = dto.LevelDropDownList.Find(e => e.Value == null);
                        selecteditem2.Selected = true;
                    }



                    if (dto.DivisionId != null)
                    {
                       
                        SelectListItem selecteditem4
                            = dto.DivisionDropDownList.Find(e => e.Value == dto.DivisionId.ToString());
                        selecteditem4.Selected = true;
                    }
                    else
                    {
                        SelectListItem selecteditem2
                                 = dto.DivisionDropDownList.Find(e => e.Value == null);
                        selecteditem2.Selected = true;
                    }
                    #endregion
                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditNotif(NotifDto NotifDto)
        {
            var Notif = Mapper.Map<NotifDto, Notif>(NotifDto);
            //add operation
            switch (NotifDto.Id)
            {
                case 0:
                    unitOfWork.NotifRepo.Insert(Notif);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة الاشعار بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.NotifRepo.Update(Notif);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الاشعار بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteNotif(int Id)
        {
            unitOfWork.NotifRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الاشعار بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}