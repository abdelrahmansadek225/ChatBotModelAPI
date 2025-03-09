﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChatBotModelAPI.Models.Roles
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}".Trim();


        [Phone]
        [Display(Name = "Phone Number")]
        public override string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email or Username")]
        public override string Email { get; set; }

        public string? ProfilePictureUrl { get; set; } = string.Empty;

        public virtual List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
        public virtual List<Message> Messages { get; set; } = new List<Message>();
    }
}
