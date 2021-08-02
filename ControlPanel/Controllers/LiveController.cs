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
    public class LiveController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public LiveController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllLives()
        {
            List<LiveDto> LiveDto = unitOfWork.LiveRepo.GetAll().ProjectTo<LiveDto>().ToList();
            return Json(new { data = LiveDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditLive(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new LiveDto()
                    {
                        MaterialDropDownList = dropdownLists.MaterialDropDownList(),
                        TrainerDropDownList = dropdownLists.TrainersDropDownList(),
                    });
                default:
                    var Live = unitOfWork.LiveRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Live, LiveDto>(Live);


                    dto.MaterialDropDownList = dropdownLists.MaterialDropDownList();
                    SelectListItem selecteditem2
                        = dto.MaterialDropDownList.Find(e => e.Value == dto.MaterialId.ToString());
                    selecteditem2.Selected = true;


                    dto.TrainerDropDownList = dropdownLists.TrainersDropDownList();
                    SelectListItem selecteditem3
                        = dto.TrainerDropDownList.Find(e => e.Value == dto.UserId.ToString());
                    selecteditem3.Selected = true;

                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditLive(LiveDto LiveDto)
        {
            var Live = Mapper.Map<LiveDto, Live>(LiveDto);
            //add operation
            switch (LiveDto.Id)
            {
                case 0:
                    unitOfWork.LiveRepo.Insert(Live);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة اللايف بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.LiveRepo.Update(Live);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل اللايف بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteLive(int Id)
        {
            unitOfWork.LiveRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف اللايف بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}