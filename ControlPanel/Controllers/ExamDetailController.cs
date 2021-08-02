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
    public class ExamDetailController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropDownLists;

        public ExamDetailController(IUnitOfWork _unitOfWork, DropDownLists dropDownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropDownLists = dropDownLists;
        }
        public ActionResult ExamDetailIndex(int id = 0)
        {
            var exam = unitOfWork.ExamRepo.GetOneBy(x => x.Id == id);
            return View(exam);
        }
        public JsonResult ViewAllExamDetails(int id)
        {
            List<ExamDetailDto> ExamDetailDto = unitOfWork.ExamDetailRepo.GetAll(x => x.ExamId == id)
                .ProjectTo<ExamDetailDto>().ToList();
            return Json(new { data = ExamDetailDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditExamDetail(int id = 0, int examId = 0)
        {
            switch (id)
            {
                case 0:

                    return View(new ExamDetailDto()
                    {
                        ExamsDropDownList = dropDownLists.ExamDropDownList(),
                        ExamId = examId,
                        RightAnswerDropDownList = dropDownLists.PopulateCorrectAnswerDropDownList()
                    });
                default:
                    var ExamDetail = unitOfWork.ExamDetailRepo.GetOneBy(x => x.Id == id);
                    var dto = Mapper.Map<ExamDetail, ExamDetailDto>(ExamDetail);

                    dto.RightAnswerDropDownList = dropDownLists.PopulateCorrectAnswerDropDownList();

                    dto.ExamsDropDownList = dropDownLists.ExamDropDownList();
                    SelectListItem selectedStore
                        = dto.ExamsDropDownList.Find(e => e.Value == dto.ExamId.ToString());
                    selectedStore.Selected = true;

                    return View(dto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditExamDetail(ExamDetailDto ExamDetailDto)
        {
            var ExamDetail = Mapper.Map<ExamDetailDto, ExamDetail>(ExamDetailDto);
            //add operation
            switch (ExamDetailDto.Id)
            {
                case 0:
                    unitOfWork.ExamDetailRepo.Insert(ExamDetail);
                    unitOfWork.Complete();
                    if (ExamDetailDto.ImageUpload != null)
                    {
                        FileUploader.UploadFTPFile(ExamDetailDto.ImageUpload.FileName
                            , ExamDetail.Id
                            , ExamDetailDto.ImageUpload
                            , Server.MapPath("~/images"));
                    }

                    return Json(new { success = true, message = "تم اضافة السؤال بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.ExamDetailRepo.Update(ExamDetail);
                    unitOfWork.Complete();
                    if (ExamDetailDto.ImageUpload != null)
                    {
                        FileUploader.UploadFTPFile(ExamDetailDto.ImageUpload.FileName
                            , ExamDetail.Id
                            , ExamDetailDto.ImageUpload
                            , Server.MapPath("~/images"));
                    }
                    return Json(new { success = true, message = "تم تعديل السؤال بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteExamDetail(int Id)
        {
            unitOfWork.ExamDetailRepo.Delete(Id);
            unitOfWork.Complete();

            FileUploader.DeleteFTPFile(Id, Server.MapPath("~/images"));
            return Json(new { success = true, message = "تم حذف السؤال بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}