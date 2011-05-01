using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

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
        [AllowHtml]
        public virtual string Body { get; set; }

        [DisplayName("Dining Date")]
        [DataType(DataType.Date)]
        public virtual DateTime DiningDate { get; set; }

        public IEnumerable<ValidationResult> 
            Validate(ValidationContext validationContext)
        {
            // custom validations ...
            return Enumerable.Empty<ValidationResult>();
        }
    }
}