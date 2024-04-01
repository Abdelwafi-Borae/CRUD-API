using AutoMapper;
using CRUD_Operation_Repository.Data;
using CRUD_Operation_Repository.Services.College_Service;

namespace CRUD_Operation_Repository.Services.Unit_Of_Work
{
    public class UnitOfWork : IunitOfWork
    {
        public Icollege_repo _college_repo { get; private set; }
        ApplicationDbContext _context;
        IMapper _mapper;

        public UnitOfWork( ApplicationDbContext context ,IMapper mapper)
        {
            _mapper=mapper;
            _context = context;
            _college_repo=new college_repo(context,_mapper);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
