using IhateThisErrorsAndBug.validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.Models;

public partial class User
{
    public int UserId { get; set; }
    [Required(ErrorMessage ="Вы должны написать имя")]
    [UserAdminValid]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage ="Пороль - обязательная часть регистрации, НЕ ЗАБЫВАЙТЕ ЕГО!")]
    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

}
