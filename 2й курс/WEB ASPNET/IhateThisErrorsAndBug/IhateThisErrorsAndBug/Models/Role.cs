using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.Models;

public partial class Role
{
    public int RoleId { get; set; }
    [Required(ErrorMessage ="Вы должны ввести название!")]
    public string RoleName { get; set; } = null!;

}
