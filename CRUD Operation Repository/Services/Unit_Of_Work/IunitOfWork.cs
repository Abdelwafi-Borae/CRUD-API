using CRUD_Operation_Repository.Services.College_Service;

namespace CRUD_Operation_Repository.Services.Unit_Of_Work
{
    public interface IunitOfWork : IDisposable
    {
        public Icollege_repo _college_repo { get;   }
        public void Complete();
        public void Dispose();

    }
}
