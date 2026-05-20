using System;
using System.Collections.Generic;

namespace powtorBD.Models;

public partial class Employee
{
    public int IdEmployees { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }


}
