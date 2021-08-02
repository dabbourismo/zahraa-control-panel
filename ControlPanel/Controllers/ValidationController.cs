using Repository.GenericRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Controllers
{
    public class ValidationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ValidationController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public JsonResult GetMaterialsByLevelId(int levelId)
        {
            var materials = new List<Material>();
            if (levelId != -1)
            {
                materials = unitOfWork.MaterialRepo.GetAll(x => x.LevelId == levelId).ToList();
            }
            else
            {
                materials = unitOfWork.MaterialRepo.GetAll().ToList();
            }

            var jsonMaterials = new List<Material>();
            jsonMaterials.Add(new Material()
            {
                Id = -1,
                Name = "الكل"
            });
            jsonMaterials.AddRange(materials);


            return Json(jsonMaterials, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetLevelsByFacultyId(int facultyId)
        {
            var levels = new List<Level>();
            if (facultyId != -1)
            {
                levels = unitOfWork.LevelRepo.GetAll(x => x.FacultyId == facultyId).ToList();
            }
            else
            {
                levels = unitOfWork.LevelRepo.GetAll().ToList();
            }


            var jsonLevels = new List<Level>();
            jsonLevels.Add(new Level()
            {
                Id = -1,
                Name = "الكل"
            });
            jsonLevels.AddRange(levels);

            return Json(jsonLevels, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult CheckUserNameDublicate(string Username, string PreviousUsername)
        {
            if (Username == PreviousUsername)
            {
                return Json(true, JsonRequestBehavior.AllowGet); ;
            }
            bool isExist = unitOfWork.UserRepo.GetOneBy(x => x.Username == Username) != null;
            if (!isExist)
            {
                Response.AddHeader("username", "متاح");
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
    }
}