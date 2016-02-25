using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Range(1,10)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024, ErrorMessage="Body is too large")]
        public string Body { get; set; }
        public int RestaurantId { get; set; }

        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]
        public string ReviewerName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //se quisermos que a mensagem apareça num detemrinado campo usamos a property

            var property = new[] { "ReviewerName" };
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("bernas")) { 
                yield return new ValidationResult("Nao podes bernas!!", property);
            }
        }
    }
}