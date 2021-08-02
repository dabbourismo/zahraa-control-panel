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
    public class DivisionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public DivisionController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllDivisions()
        {
            List<DivisionDto> DivisionDto = unitOfWork.DivisionRepo.GetAll().ProjectTo<DivisionDto>().ToList();
            return Json(new { data = DivisionDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditDivision(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new DivisionDto()
                    {
                        LevelDropDownList = dropdownLists.LevelDropDownList(false),
                    });
                default:
                    var Division = unitOfWork.DivisionRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Division, DivisionDto>(Division);

                    dto.LevelDropDownList = dropdownLists.LevelDropDownList(false);
                    SelectListItem selecteditem
                        = dto.LevelDropDownList.Find(e => e.Value == dto.LevelId.ToString());
                    selecteditem.Selected = true;

                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditDivision(DivisionDto DivisionDto)
        {
            var Division = Mapper.Map<DivisionDto, Division>(DivisionDto);
            //add operation
            switch (DivisionDto.Id)
            {
                case 0:
                    unitOfWork.DivisionRepo.Insert(Division);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة القسم بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.DivisionRepo.Update(Division);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل القسم بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteDivision(int Id)
        {
            unitOfWork.DivisionRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف القسم بنجاح" }, JsonRequestBehavior.AllowGet);
        }

    }
}