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
    public class LectureController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public LectureController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllLectures()
        {
            List<LectureDto> LectureDto = unitOfWork.LectureRepo.GetAll().ProjectTo<LectureDto>().ToList();
            return Json(new { data = LectureDto }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddEditLecture(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new LectureDto()
                    {
                        MaterialDropDownList = dropdownLists.MaterialDropDownList(),
                        TrainerDropDownList = dropdownLists.TrainersDropDownList(),
                    });
                default:
                    var Lecture = unitOfWork.LectureRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Lecture, LectureDto>(Lecture);


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
        public ActionResult AddEditLecture(LectureDto LectureDto)
        {
            var Lecture = Mapper.Map<LectureDto, Lecture>(LectureDto);
            //add operation
            switch (LectureDto.Id)
            {
                case 0:
                    unitOfWork.LectureRepo.Insert(Lecture);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة المحاضرة بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.LectureRepo.Update(Lecture);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل المحاضرة بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteLecture(int Id)
        {
            unitOfWork.LectureRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف المحاضرة بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}