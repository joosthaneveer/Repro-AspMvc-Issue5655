using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication3.ViewModels
{
    public class AssignmentViewModel : IValidatableObject
    {
        public AssignmentViewModel()
        {
            ContactPersons = new List<ContactPersonViewModel>();
        }

        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Address { get; set; }

                [MinLength(1)]
        public List<ContactPersonViewModel> ContactPersons { get; set; }

        [Required]
        public DateTime CountDate { get; set; }

        [Required]
        [MaxLength(1000)]
        public string BasicInstruction { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FinalDeliverableListing { get; set; }

        [Required]
        [Range(1, 1000)]
        public int ExpectedNumberOfItems { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CountDate.ToUniversalTime() < DateTime.UtcNow)
                yield return new ValidationResult("Count Date must be in the future", new[] { "CountDate" });
        }
    }
}