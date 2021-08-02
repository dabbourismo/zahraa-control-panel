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
    public class ExamController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public ExamController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllExams()
        {
            List<ExamDto> ExamDto = unitOfWork.ExamRepo.GetAll().ProjectTo<ExamDto>().ToList();
            return Json(new { data = ExamDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditExam(int id = 0)
        {
            Session["numberOfTrainers"] = unitOfWork.UserRepo.GetAll(x => x.UserType == Repository.Models.Enums.EnumUserType.Trainer).Count();
            Session["numberOfMaterials"] = unitOfWork.MaterialRepo.GetAll().Count();
            switch (id)
            {
                case 0:
                    return View(new ExamDto()
                    {
                        MaterialDropDownList = dropdownLists.MaterialDropDownList(),
                        UserDropDownList = dropdownLists.TrainersDropDownList()
                    });
                default:
                    var Exam = unitOfWork.ExamRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Exam, ExamDto>(Exam);

                    dto.MaterialDropDownList = dropdownLists.MaterialDropDownList();
                    dto.UserDropDownList = dropdownLists.TrainersDropDownList();

                    SelectListItem selecteditem
                        = dto.MaterialDropDownList.Find(e => e.Value == dto.MaterialId.ToString());
                    selecteditem.Selected = true;

                    SelectListItem selecteditem2
                         = dto.UserDropDownList.Find(e => e.Value == dto.UserId.ToString());
                    selecteditem.Selected = true;

                    return View(dto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditExam(ExamDto ExamDto)
        {
            var Exam = Mapper.Map<ExamDto, Exam>(ExamDto);
            //add operation
            switch (ExamDto.Id)
            {
                case 0:
                    unitOfWork.ExamRepo.Insert(Exam);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة الاختبار بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.ExamRepo.Update(Exam);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الاختبار بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteExam(int Id)
        {
            unitOfWork.ExamRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الاختبار بنجاح" }, JsonRequestBehavior.AllowGet);
        }

    }
}