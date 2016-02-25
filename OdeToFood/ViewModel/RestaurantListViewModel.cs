using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.ViewModel
{
    public class RestaurantListViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Body is too large")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public int ReviewsCount { get; set; }
        public bool HasError { get; set; }
    }
}