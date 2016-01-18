using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class HomeModels
    {

        [Required(ErrorMessage = "Your Name is required")]
        public string Name { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Your Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please type your message")]
        public string Message { get; set; }
    }
}