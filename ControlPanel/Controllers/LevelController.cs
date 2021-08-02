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
    public class LevelController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public LevelController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllLevels()
        {
            List<LevelDto> LevelDto = unitOfWork.LevelRepo.GetAll().ProjectTo<LevelDto>().ToList();
            return Json(new { data = LevelDto }, JsonRequestBehavior.AllowGet);
        }

   

        [HttpGet]
        public ActionResult AddEditLevel(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new LevelDto()
                    {
                        FacultyDropDownList = dropdownLists.FacultyDropDownList(false),
                    });
                default:
                    var Level = unitOfWork.LevelRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Level, LevelDto>(Level);

                    dto.FacultyDropDownList = dropdownLists.FacultyDropDownList(false);
                    SelectListItem selecteditem
                        = dto.FacultyDropDownList.Find(e => e.Value == dto.FacultyId.ToString());
                    selecteditem.Selected = true;

                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditLevel(LevelDto LevelDto)
        {
            var Level = Mapper.Map<LevelDto, Level>(LevelDto);
            //add operation
            switch (LevelDto.Id)
            {
                case 0:
                    unitOfWork.LevelRepo.Insert(Level);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة المرحلة بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.LevelRepo.Update(Level);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل المرحلة بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteLevel(int Id)
        {
            unitOfWork.LevelRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف المرحلة بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}