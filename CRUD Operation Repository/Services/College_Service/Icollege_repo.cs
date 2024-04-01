using CRUD_Operation_Repository.DTOS;
using CRUD_Operation_Repository.Models;
using CRUD_Operation_Repository.Services.Common_service;

namespace CRUD_Operation_Repository.Services.College_Service
{
    public interface Icollege_repo: ICommon_Service<College>  
    {
        public Task< Response<Mapped_College>> GetMapped_College(int Id);
    }
}
