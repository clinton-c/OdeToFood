using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OdeToFood.Models
{
    public class Review : IValidatableObject
    {
        public virtual int ID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        
        [Range(1, 10)]
        public virtual int Rating { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Body { get; set; }

        [DisplayName("Dining Date")]
        [DataType(DataType.Date)]
        public virtual DateTime DiningDate { get; set; }

        public IEnumerable<ValidationResult> 
            Validate(ValidationContext validationContext)
        {
            var field = new[] { "DiningDate" };

            if (DiningDate > DateTime.Now)
            {
                yield return new ValidationResult("Dining date can not be in the future.", field);
            }

            if (DiningDate < DateTime.Now.AddYears(-1))
            {
                yield return new ValidationResult("Dining date cannot be too far in the past.", field);
            }
        }
    }
}