using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.DtoObjects.Employee
{
    public class CreateEmployeeDto
    {

        public string? Name { get; set; }

        public string? LastName { get; set; }


        public DateTime BirthDate { get; set; }


        public string? Role { get; set; }


        public string? Description { get; set; }
    }
}
