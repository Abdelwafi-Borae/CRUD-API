using AutoMapper;
using CRUD_Operation_Repository.DTOS;
using CRUD_Operation_Repository.Models;

namespace CRUD_Operation_Repository.Mapping
{
    public class CollegeProfile : Profile
    {
        public CollegeProfile()
        {
            CreateMap<College, CreateCollegeDto>().ReverseMap();
            CreateMap<Mapped_College, College>().ReverseMap();
        }
    }
}
