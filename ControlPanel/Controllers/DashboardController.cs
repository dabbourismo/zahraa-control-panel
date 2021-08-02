using ControlPanel.Models;
using ControlPanel.Services;
using Repository;
using Repository.GenericRepo;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ControlPanel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext context;
        DropDownLists dropdownLists;
        public DashboardController(IUnitOfWork _unitOfWork, DropDownLists dropdownLists)
        {
            context = new AppDbContext();
            this.dropdownLists = dropdownLists;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var dto = new DashboardDto()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                FacultyDropDownList = dropdownLists.FacultyDropDownListDashboard(true),
                LevelDropDownList = dropdownLists.LevelDropDownListDashboard(true),
                MaterialDropDownList = dropdownLists.MaterialDropDownListDashboard()
            };

            dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student &&
                                    x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();

            dto.Purchases = context.Payments.Where(x => x.BuyDate >= DateTime.MinValue && x.BuyDate <= DateTime.MaxValue).Sum(z => z.Payed);

            return View(dto);
        }


        [HttpPost]
        public ActionResult Index(DashboardDto dto)
        {
            dto.FacultyDropDownList = dropdownLists.FacultyDropDownListDashboard(true);
            SelectListItem faculty
                     = dto.FacultyDropDownList.Find(e => e.Value == dto.FacultyId.ToString() || e.Value == "-1");
            faculty.Selected = true;


            dto.LevelDropDownList = dropdownLists.LevelDropDownListDashboard(true);
            SelectListItem level
                     = dto.LevelDropDownList.Find(e => e.Value == dto.LevelId.ToString() || e.Value == "-1");
            level.Selected = true;


            dto.MaterialDropDownList = dropdownLists.MaterialDropDownListDashboard();
            SelectListItem material
                     = dto.MaterialDropDownList.Find(e => e.Value == dto.MaterialId.ToString() || e.Value == "-1");
            material.Selected = true;

            //AllFaculty-AllLevels-AllMaterials
            if (dto.FacultyId == -1 && dto.LevelId == -1 && dto.MaterialId == -1)
            {
                dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student &&
                                   x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();
            }
            //AllFaculty-SelectedLevel-AllMaterials
            else if (dto.FacultyId == -1 && dto.LevelId != -1 && dto.MaterialId == -1)
            {
                dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student
                                  && x.LevelId == dto.LevelId
                                  && x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();
            }
            //AllFaculty-AllLevels-SelectedMaterial
            else if (dto.FacultyId == -1 && dto.LevelId == -1 && dto.MaterialId != -1)
            {
                var selectedMaterial = context.Materials.Find(dto.MaterialId);
                var levelOfMaterial = context.Levels.Find(selectedMaterial.LevelId);

                dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student
                                  && x.LevelId == levelOfMaterial.Id
                                  && x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();
            }
            //SelectedFaculty-AllLevels-AllMaterials
            else if (dto.FacultyId != -1 && dto.LevelId == -1 && dto.MaterialId == -1)
            {
                dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student
                                  && x.FacultyId == dto.FacultyId
                                  && x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();
            }
            //SelectedFaculty-SelectedLevels-AllMaterials
            else if (dto.FacultyId != -1 && dto.LevelId != -1 && dto.MaterialId == -1)
            {
                dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student
                                  && x.LevelId == dto.LevelId
                                  && x.FacultyId == dto.FacultyId
                                  && x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();
            }
            //SelectedFaculty-SelectedLevels-SelectedMaterial
            else if (dto.FacultyId != -1 && dto.LevelId != -1 && dto.MaterialId == -1)
            {
                dto.RegisteredStudents = context.Users.Where(x => x.UserType == Repository.Models.Enums.EnumUserType.Student
                                  && x.LevelId == dto.LevelId
                                  && x.FacultyId == dto.FacultyId
                                  && x.RegisterDate >= DateTime.MinValue && x.RegisterDate <= DateTime.MaxValue).Count();
            }



            dto.Purchases = context.Payments.Where(x => x.BuyDate >= dto.FromDate && x.BuyDate <= dto.ToDate)
                .Select(x => x.Payed)
                .DefaultIfEmpty(0)
                .Sum();


            return View(dto);
        }
    }
}