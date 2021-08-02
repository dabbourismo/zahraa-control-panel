using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepo
{
    public interface IUnitOfWork
    {
        UserRepository UserRepo { get; }
        DivisionRepository DivisionRepo { get; }
        FacultyRepository FacultyRepo { get; }
        LevelRepository LevelRepo { get; }
        LiveRepository LiveRepo { get; }
        LectureRepository LectureRepo { get; }
        MaterialRepository MaterialRepo { get; }
        NotifRepository NotifRepo { get; }
        PaymentRepository PaymentRepo { get; }
        PaymentDetailRepository PaymentDetailRepo { get; }
        NewsRepository NewsRepo { get; }
        ExamRepository ExamRepo { get; }

        ExamDetailRepository ExamDetailRepo { get; }

        HomeworkRepository HomeworkRepo { get; }

        int Complete();
    }
}
