using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPanel.Services
{
    public class DropDownLists
    {
        private readonly IUnitOfWork unitOfWork;
        public DropDownLists(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public List<SelectListItem> FacultyDropDownListDashboard(bool containsAll)
        {
            var list = new List<SelectListItem>();
            if (containsAll)
            {
                list.Add(new SelectListItem
                {
                    Text = "الكل",
                    Value = "-1"
                });
            }

            var items = unitOfWork.FacultyRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد كليات مسجلة",Value = null}
                };
            }
        }


        public List<SelectListItem> LevelDropDownListDashboard(bool containsAll)
        {
            var list = new List<SelectListItem>();
            if (containsAll)
            {
                list.Add(new SelectListItem
                {
                    Text = "الكل",
                    Value = "-1"
                });
            }
            var items = unitOfWork.LevelRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد مراحل مسجلة",Value = null}
                };
            }
        }


        public List<SelectListItem> MaterialDropDownListDashboard()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem
            {
                Text = "الكل",
                Value = "-1"
            });

            var items = unitOfWork.MaterialRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد مواد مسجلة",Value = null}
                };
            }
        }
        public  List<SelectListItem> PopulateCorrectAnswerDropDownList()
        {
            var rightAnswers = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Answer 1" },
                new SelectListItem { Value = "2", Text = "Answer 2" },
                new SelectListItem { Value = "3", Text = "Answer 3" },
                new SelectListItem { Value = "4", Text = "Answer 4" },
                new SelectListItem { Value = "5", Text = "Answer 5" },
            };
            return rightAnswers;
        }

        public List<SelectListItem> ExamDropDownList()
        {
            var list = new List<SelectListItem>();
            var items = unitOfWork.ExamRepo.GetAll().Select(c => new { c.Id, c.ExamName }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.ExamName.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد اختبارات مسجلة",Value = null}
                };
            }
        }

        public List<SelectListItem> FacultyDropDownList(bool containsAll)
        {
            var list = new List<SelectListItem>();
            if (containsAll)
            {
                list.Add(new SelectListItem
                {
                    Text = "الكل",
                    Value = null
                });
            }
           
            var items = unitOfWork.FacultyRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد كليات مسجلة",Value = null}
                };
            }
        }


        public List<SelectListItem> LevelDropDownList(bool containsAll)
        {
            var list = new List<SelectListItem>();
            if (containsAll)
            {
                list.Add(new SelectListItem
                {
                    Text = "الكل",
                    Value = null
                });
            }
            var items = unitOfWork.LevelRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد مراحل مسجلة",Value = null}
                };
            }
        }


        public List<SelectListItem> DivisionDropDownList(bool containsAll)
        {
            var list = new List<SelectListItem>();
            if (containsAll)
            {
                list.Add(new SelectListItem
                {
                    Text = "الكل",
                    Value = null
                });
            }
            var items = unitOfWork.DivisionRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد اقسام مسجلة",Value = null}
                };
            }
        }


        public List<SelectListItem> MaterialDropDownList()
        {
            var list = new List<SelectListItem>();
            var items = unitOfWork.MaterialRepo.GetAll().Select(c => new { c.Id, c.Name }).ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد مواد مسجلة",Value = null}
                };
            }
        }


        public List<SelectListItem> TrainersDropDownList()
        {
            var list = new List<SelectListItem>();           
            var items = unitOfWork.UserRepo.GetAll()
                .Where(x=>x.UserType == Repository.Models.Enums.EnumUserType.Trainer)
                .Select(c => new { c.Id, c.Name })
                .ToList();

            foreach (var item in items)
            {
                list.Add(new SelectListItem
                {
                    Text = item.Name.ToString(),
                    Value = item.Id.ToString()
                });

            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem {Text = "لا يوجد مدربين مسجلين",Value = null}
                };
            }
        }
    }
}