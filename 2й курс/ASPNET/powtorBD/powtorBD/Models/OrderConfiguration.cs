using System;
using System.Collections.Generic;

namespace powtorBD.Models;

public partial class OrderConfiguration
{
    public int IdOrderConfiguration { get; set; }

    public int Quantity { get; set; }

    public string Unit { get; set; } = null!;

    public int IdSize { get; set; }

    public int IdOrder { get; set; }


}
