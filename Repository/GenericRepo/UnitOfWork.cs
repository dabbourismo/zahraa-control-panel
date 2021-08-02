using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
            UserRepo = new UserRepository(context);
            DivisionRepo = new DivisionRepository(context);
            FacultyRepo = new FacultyRepository(context);
            LevelRepo = new LevelRepository(context);
            LiveRepo = new LiveRepository(context);
            LectureRepo = new LectureRepository(context);
            MaterialRepo = new MaterialRepository(context);
            NotifRepo = new NotifRepository(context);
            PaymentRepo = new PaymentRepository(context);
            PaymentDetailRepo = new PaymentDetailRepository(context);
            NewsRepo = new NewsRepository(context);
            ExamRepo = new ExamRepository(context);

            ExamDetailRepo = new ExamDetailRepository(context);
            HomeworkRepo = new HomeworkRepository(context);
        }

        public UserRepository UserRepo { get; private set; }
        public DivisionRepository DivisionRepo { get; private set; }
        public FacultyRepository FacultyRepo { get; private set; }
        public LevelRepository LevelRepo { get; private set; }
        public LiveRepository LiveRepo { get; private set; }
        public LectureRepository LectureRepo { get; private set; }

        public MaterialRepository MaterialRepo { get; private set; }
        public NotifRepository NotifRepo { get; private set; }
        public PaymentRepository PaymentRepo { get; private set; }
        public PaymentDetailRepository PaymentDetailRepo { get; private set; }

        public NewsRepository NewsRepo { get; private set; }
        public ExamRepository ExamRepo { get; private set; }

        public ExamDetailRepository ExamDetailRepo { get; private set; }
        public HomeworkRepository HomeworkRepo { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
