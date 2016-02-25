using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.ViewModel
{
    public class EditUserRolesViewModel
    {
        public String UserName { get; set; }
        [Display(Name = "Current Roles")]
        public List<String> CurrentRoles { get; set; }
        public int SelectedRoleId { get; set; }
        [Display(Name = "Add Role")]
        public List<String> Roles { get; set; }
    }
}