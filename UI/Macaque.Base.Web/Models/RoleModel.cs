using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Macaque.Base.Web.Models
{
    public class RoleModel : _ModelBase
    {
        [Required]
        [Display(Name = "Role Code")]
        public string RoleCode { get; set; }

        [Required]
        [Display(Name = "Role Description")]
        public string RoleDesc { get; set; }
    }
}
