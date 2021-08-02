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
    public class HomeworkController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public HomeworkController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllHomeworks()
        {
            List<HomeworkDto> HomeworkDto = unitOfWork.HomeworkRepo.GetAll().ProjectTo<HomeworkDto>().ToList();
            return Json(new { data = HomeworkDto }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddEditHomework(int id = 0, int examId = 0)
        {
            switch (id)
            {
                case 0:

                    return View(new HomeworkDto()
                    {
                        MaterialsDropDownList = dropdownLists.MaterialDropDownList(),

                    });
                default:
                    var Homework = unitOfWork.HomeworkRepo.GetOneBy(x => x.Id == id);
                    var dto = Mapper.Map<Homework, HomeworkDto>(Homework);

                    dto.MaterialsDropDownList = dropdownLists.MaterialDropDownList();
                    SelectListItem selectedStore
                        = dto.MaterialsDropDownList.Find(e => e.Value == dto.MaterialId.ToString());
                    selectedStore.Selected = true;

                    return View(dto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditHomework(HomeworkDto HomeworkDto)
        {
            int trainerId = (int)Session["userId"];
            HomeworkDto.isValid = false;
            HomeworkDto.UserId = trainerId;
            var Homework = Mapper.Map<HomeworkDto, Homework>(HomeworkDto);
            //add operation
            switch (HomeworkDto.Id)
            {
                case 0:
                    unitOfWork.HomeworkRepo.Insert(Homework);
                    unitOfWork.Complete();
                    if (HomeworkDto.HomeworkFile != null)
                    {

                        FileUploader.UploadFTPFile(HomeworkDto.HomeworkFile.FileName
                       , Homework.Id
                       , HomeworkDto.HomeworkFile
                       , Server.MapPath("~/homeworks"));

                    }
                    return Json(new { success = true, message = "تم اضافة الواجب بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.HomeworkRepo.Update(Homework);
                    unitOfWork.Complete();
                    if (HomeworkDto.HomeworkFile != null)
                    {

                        FileUploader.UploadFTPFile(HomeworkDto.HomeworkFile.FileName
                       , Homework.Id
                       , HomeworkDto.HomeworkFile
                       , Server.MapPath("~/homeworks"));
                        HomeworkDto.isValid = true;

                    }
                    return Json(new { success = true, message = "تم تعديل الواجب بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteHomework(int Id)
        {
            unitOfWork.HomeworkRepo.Delete(Id);
            unitOfWork.Complete();

            FileUploader.DeleteFTPFile(Id, Server.MapPath("~/homeworks"));
            return Json(new { success = true, message = "تم حذف الواجب بنجاح" }, JsonRequestBehavior.AllowGet);
        }


        public void DownLoadFile(int id)
        {
            Redirect(Paths.HomeworkPath + id + ".pdf");
        }
    }
}