using CRUD_Operation_Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation_Repository.DTOS
{
    public class CreateCollegeDto
    {


        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

    }
}