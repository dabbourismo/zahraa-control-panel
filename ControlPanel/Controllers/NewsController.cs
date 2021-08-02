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
    public class NewsController : Controller
    {
        private DropDownLists dropdownLists;
        private readonly IUnitOfWork unitOfWork;
        public NewsController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            this.unitOfWork = _unitOfWork;
            this.dropdownLists = dropdownLists;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ViewAllNews()
        {
            List<NewsDto> NewsDto = unitOfWork.NewsRepo.GetAll().ProjectTo<NewsDto>().ToList();
            return Json(new { data = NewsDto }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddEditNews(int id = 0)
        {
            switch (id)
            {
                case 0:
                    return View(new NewsDto()
                    {
                        FacultyDropDownList = dropdownLists.FacultyDropDownList(true)
                    });
                default:
                    var News = unitOfWork.NewsRepo.GetOneBy(x => x.Id == id);
                    var dto = Mapper.Map<News, NewsDto>(News);


                    dto.FacultyDropDownList = dropdownLists.FacultyDropDownList(true);
                    if (dto.FacultyId != null)
                    {
                        SelectListItem selecteditem3
                        = dto.FacultyDropDownList.Find(e => e.Value == dto.FacultyId.ToString());
                        selecteditem3.Selected = true;

                        return View(dto);
                    }
                    SelectListItem selecteditem4
                        = dto.FacultyDropDownList.Find(e => e.Value == null);
                    selecteditem4.Selected = true;


                    return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditNews(NewsDto NewsDto)
        {
            var News = Mapper.Map<NewsDto, News>(NewsDto);
            //add operation
            switch (NewsDto.Id)
            {
                case 0:
                    unitOfWork.NewsRepo.Insert(News);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة الخبر بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.NewsRepo.Update(News);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل الخبر بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteNews(int Id)
        {
            unitOfWork.NewsRepo.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف الخبر بنجاح" }, JsonRequestBehavior.AllowGet);
        }

    }
}