using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        // EF Core will configure the database to generate this value
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        public string First { get; set; }



        [Required(ErrorMessage = "Please enter last name.")]
        public string Last { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }


        public DateTime DateAdded {  get; set; }

        [Required(ErrorMessage = "Please enter a Category.")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
