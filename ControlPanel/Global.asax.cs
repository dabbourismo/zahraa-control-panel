using ControlPanel.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControlPanel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalFilters.Filters.Add(new RequireHttpsAttribute());

            UnityConfig.RegisterComponents();
            AutoMapperWebProfile.Run();
         
        }
    }

    internal class AutoMapperWebProfile : AutoMapper.Profile
    {
        public static void Run() => AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutoMapperWebProfile>(); });

        public AutoMapperWebProfile()
        {
            AllowNullDestinationValues = true;

           
            CreateMap<Faculty, FacultyDto>();
            CreateMap<FacultyDto, Faculty>();

            CreateMap<News, NewsDto>()
                .ForMember(dto => dto.FacultyName, opt => opt.MapFrom(obj => obj.Faculty.Name));
            CreateMap<NewsDto, News>();

            CreateMap<Level, LevelDto>()
            .ForMember(dto => dto.FacultyName, opt => opt.MapFrom(obj => obj.Faculty.Name));
            CreateMap<LevelDto, Level>();

            CreateMap<Homework, HomeworkDto>()
            .ForMember(dto => dto.MaterialName, opt => opt.MapFrom(obj => obj.Material.Name));
            CreateMap<HomeworkDto, Homework>();

            CreateMap<Division, DivisionDto>()
            .ForMember(dto => dto.LevelName, opt => opt.MapFrom(obj => obj.Level.Name));
            CreateMap<DivisionDto, Division>();

            CreateMap<User, UserDto>()
           .ForMember(dto => dto.FacultyName, opt => opt.MapFrom(obj => obj.Faculty.Name))
           .ForMember(dto => dto.LevelName, opt => opt.MapFrom(obj => obj.Level.Name))
           .ForMember(dto => dto.DivisionName, opt => opt.MapFrom(obj => obj.Division.Name));
            CreateMap<UserDto, User>();

            CreateMap<Material, MaterialDto>()
            .ForMember(dto => dto.DivisionName, opt => opt.MapFrom(obj => obj.Division.Name))
            .ForMember(dto => dto.LevelName, opt => opt.MapFrom(obj => obj.Level.Name));
            CreateMap<MaterialDto, Material>();


            CreateMap<Exam, ExamDto>()
           .ForMember(dto => dto.UserName, opt => opt.MapFrom(obj => obj.User.Name))
           .ForMember(dto => dto.MaterialName, opt => opt.MapFrom(obj => obj.Material.Name));
            CreateMap<ExamDto, Exam>();


            CreateMap<Live, LiveDto>()
            .ForMember(dto => dto.UserName, opt => opt.MapFrom(obj => obj.User.Name))
            .ForMember(dto => dto.MaterialName, opt => opt.MapFrom(obj => obj.Material.Name));
            CreateMap<LiveDto, Live>();

            CreateMap<PaymentDetail, PaymentDetailDto>()
            .ForMember(dto => dto.Username, opt => opt.MapFrom(obj => obj.User.Name));
            CreateMap<PaymentDetailDto, PaymentDetail>();

            CreateMap<ExamDetail, ExamDetailDto>()
           .ForMember(dto => dto.ExamName, opt => opt.MapFrom(obj => obj.Exam.ExamName));
            CreateMap<ExamDetailDto, ExamDetail>();

            CreateMap<Lecture, LectureDto>()
            .ForMember(dto => dto.UserName, opt => opt.MapFrom(obj => obj.User.Name))
            .ForMember(dto => dto.MaterialName, opt => opt.MapFrom(obj => obj.Material.Name));
            CreateMap<LectureDto, Lecture>();


            CreateMap<Notif, NotifDto>()
           .ForMember(dto => dto.FacultyName, opt => opt.MapFrom(obj => obj.Faculty.Name))
           .ForMember(dto => dto.LevelName, opt => opt.MapFrom(obj => obj.Level.Name))
           .ForMember(dto => dto.DivisionName, opt => opt.MapFrom(obj => obj.Division.Name));
            CreateMap<NotifDto, Notif>();
        }
    }
}
