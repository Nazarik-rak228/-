using System;
using System.Collections.Generic;

namespace powtorBD.Models;

public partial class AddressCustomer
{
    public int IdAddress { get; set; }

    public string Street { get; set; } = null!;

    public int House { get; set; }

    public int CityId { get; set; }


}
