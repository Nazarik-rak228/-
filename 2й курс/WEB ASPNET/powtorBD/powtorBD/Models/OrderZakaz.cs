using System;
using System.Collections.Generic;

namespace powtorBD.Models;

public partial class OrderZakaz
{
    public int IdOrder { get; set; }

    public DateOnly DateOrder { get; set; }

    public int IdCustomer { get; set; }

    public int IdStatus { get; set; }

    public int IdEmployees { get; set; }

    public int IdProduct { get; set; }

    public int IdColour { get; set; }

    
}
