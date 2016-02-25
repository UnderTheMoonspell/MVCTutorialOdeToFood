using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(512, ErrorMessage = "Body is too large")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public virtual ICollection<RestaurantReview> Reviews {get;set;}
    }
}