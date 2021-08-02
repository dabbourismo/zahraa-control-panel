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
    public class MaterialController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private DropDownLists dropdownLists;
        public MaterialController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllMaterials()
        {
            List<MaterialDto> MaterialDto = unitOfWork.MaterialRepo.GetAll().ProjectTo<MaterialDto>().ToList();
            return Json(new { data = MaterialDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditMaterial(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new MaterialDto()
                    {
                        LevelDropDownList = dropdownLists.LevelDropDownList(false),
                        DivisionDropDownList = dropdownLists.DivisionDropDownList(true),
                    });
                default:
                    var Material = unitOfWork.MaterialRepo.GetOneBy(x => x.Id == id);

                    var dto = Mapper.Map<Material, MaterialDto>(Material);


                    dto.LevelDropDownList = dropdownLists.LevelDropDownList(false);
                    SelectListItem selecteditem2
                        = dto.LevelDropDownList.Find(e => e.Value == dto.LevelId.ToString());
                    selecteditem2.Selected = true;


                    dto.DivisionDropDownList = dropdownLists.DivisionDropDownList(true);
                    if (dto.DivisionId != null)
                    {
                        SelectListItem selecteditem3
                        = dto.DivisionDropDownList.Find(e => e.Value == dto.DivisionId.ToString());
                        selecteditem3.Selected = true;

                        return View(dto);
                    }
                    SelectListItem selecteditem4
                        = dto.DivisionDropDownList.Find(e => e.Value == null);
                    selecteditem4.Selected = true;

                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditMaterial(MaterialDto MaterialDto)
        {
            var Material = Mapper.Map<MaterialDto, Material>(MaterialDto);
            //add operation
            switch (MaterialDto.Id)
            {
                case 0:
                    unitOfWork.MaterialRepo.Insert(Material);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة المادة بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.MaterialRepo.Update(Material);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل المادة بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteMaterial(int Id)
        {
            unitOfWork.MaterialRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف المادة بنجاح" }, JsonRequestBehavior.AllowGet);
        }

     
    }
}