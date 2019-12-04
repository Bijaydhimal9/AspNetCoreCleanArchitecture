using System.ComponentModel.DataAnnotations;

namespace Web.Models.RequestModels
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
