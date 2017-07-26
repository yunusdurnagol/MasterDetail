using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetail.ViewModels
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "You must enter a name for the model")]
        [StringLength(256,ErrorMessage = "The Role name must be lower than 256 characters..")]
        [Display(Name = "Role Name")]
        public string Name { get; set; }

    
    }
}