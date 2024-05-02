using System.ComponentModel.DataAnnotations;

namespace MvcCrudOperetionWithDependecy.Models
{
    public class Carmodel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(11, ErrorMessage = "max lengt must be 11 character")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Brand is Required")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model is Required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "CarYear is Required")]
        public int CarYear { get; set; }
    }
}
