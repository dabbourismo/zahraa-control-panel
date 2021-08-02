using Repository.GenericRepo;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repos
    {
    }
    public class DivisionRepository : GenericRepository<Division>
    {
        private readonly AppDbContext context;
        public DivisionRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }
    
    public class FacultyRepository : GenericRepository<Faculty>
    {
        private readonly AppDbContext context;
        public FacultyRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class LevelRepository : GenericRepository<Level>
    {
        private readonly AppDbContext context;
        public LevelRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class LiveRepository : GenericRepository<Live>
    {
        private readonly AppDbContext context;
        public LiveRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class LectureRepository : GenericRepository<Lecture>
    {
        private readonly AppDbContext context;
        public LectureRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class MaterialRepository : GenericRepository<Material>
    {
        private readonly AppDbContext context;
        public MaterialRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class NotifRepository : GenericRepository<Notif>
    {
        private readonly AppDbContext context;
        public NotifRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class PaymentRepository : GenericRepository<Payment>
    {
        private readonly AppDbContext context;
        public PaymentRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }
    public class UserRepository : GenericRepository<User>
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class PaymentDetailRepository : GenericRepository<PaymentDetail>
    {
        private readonly AppDbContext context;
        public PaymentDetailRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class NewsRepository : GenericRepository<News>
    {
        private readonly AppDbContext context;
        public NewsRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class ExamRepository : GenericRepository<Exam>
    {
        private readonly AppDbContext context;
        public ExamRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class ExamDetailRepository : GenericRepository<ExamDetail>
    {
        private readonly AppDbContext context;
        public ExamDetailRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }

    public class HomeworkRepository : GenericRepository<Homework>
    {
        private readonly AppDbContext context;
        public HomeworkRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

    }


    



}
