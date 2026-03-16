using System;
using System.Collections.Generic;

namespace powtorBD.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string NameC { get; set; } = null!;

    public int AddressId { get; set; }


}
