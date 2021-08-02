using AutoMapper;
using AutoMapper.QueryableExtensions;
using ControlPanel.Models;
using Repository.GenericRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public FacultyController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllFacultys()
        {
            List<FacultyDto> FacultyDto = unitOfWork.FacultyRepo.GetAll().ProjectTo<FacultyDto>().ToList();
            return Json(new { data = FacultyDto }, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult AddEditFaculty(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new FacultyDto());
                default:
                    var faculty = unitOfWork.FacultyRepo.GetOneBy(x => x.Id == id);
                    var dto = Mapper.Map<Faculty, FacultyDto>(faculty);                
                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditFaculty(FacultyDto FacultyDto)
        {
            var Faculty = Mapper.Map<FacultyDto, Faculty>(FacultyDto);
            //add operation
            switch (FacultyDto.Id)
            {
                case 0:
                    unitOfWork.FacultyRepo.Insert(Faculty);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة الكلية بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.FacultyRepo.Update(Faculty);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الكلية بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteFaculty(int Id)
        {
            unitOfWork.FacultyRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الكلية بنجاح" }, JsonRequestBehavior.AllowGet);
        }

    }
}