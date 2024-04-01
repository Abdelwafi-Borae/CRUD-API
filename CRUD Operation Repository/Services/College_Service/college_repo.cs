using AutoMapper;
using CRUD_Operation_Repository.Data;
using CRUD_Operation_Repository.DTOS;
using CRUD_Operation_Repository.Models;
using CRUD_Operation_Repository.Services.Common_service;

namespace CRUD_Operation_Repository.Services.College_Service
{
    public class college_repo : Common_Service<College>, Icollege_repo
    {
        private IMapper mapper;
        public college_repo(ApplicationDbContext context , IMapper mapper) : base(context)
        {
            this.mapper = mapper;
            
        }

        public async Task<Response<Mapped_College>> GetMapped_College(int Id)
        {
            College college=await GetByID(Id);
            
            if(college==null)
                return new Response<Mapped_College> { Message="no data found found",StatusCode=401,Data=null};
             
            Mapped_College mappeddata = mapper.Map<Mapped_College>(college);
        
            return new Response<Mapped_College> { Message = "dd", StatusCode = 200, Data = mappeddata };
        }
    }
}
//sscff
///dd
///dd