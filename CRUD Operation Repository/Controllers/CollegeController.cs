using AutoMapper;
using CRUD_Operation_Repository.DTOS;
using CRUD_Operation_Repository.Models;
using CRUD_Operation_Repository.Services.Unit_Of_Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CRUD_Operation_Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly IunitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CollegeController(IunitOfWork iunit, IMapper mapper)
        {
            _unitOfWork = iunit;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCollegeAsync(CreateCollegeDto createCollegeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                College college = _mapper.Map<College>(createCollegeDto);
                _unitOfWork._college_repo.AddItem(college);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                return Ok("new item added successfully");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var college = await _unitOfWork._college_repo.GetMapped_College(Id);
            
            return Ok(college);

        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _unitOfWork._college_repo.GetByCrateria(c => c.Name.Contains(name)));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var colleges = await _unitOfWork._college_repo.GetAll();
            if (colleges == null)
                return NoContent();
            return Ok(colleges);

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveCollege(int Id)
        {
          var college= await _unitOfWork._college_repo.GetByID(Id);
            if(college == null)
                return BadRequest("no college found with the id:"+ Id);
            _unitOfWork._college_repo.RemoveItem(college);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok("deleted successfully");

        }
        
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCollege(int Id,JsonPatchDocument<College> patchdouc)
        {
            var college = await _unitOfWork._college_repo.GetByID(Id);
            if (college == null)
                return BadRequest("no college found with the id:" + Id);
            patchdouc.ApplyTo(college, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState + "something went wrong");
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok(college);


        }

        

    }
}
