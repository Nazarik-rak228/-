using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "это поле обязательно!")]
    public string CategoryName { get; set; } = null!;


}
