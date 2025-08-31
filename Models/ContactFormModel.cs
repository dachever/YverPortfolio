﻿using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }
    }
}
