using System;
using System.Collections.Generic;

namespace BD1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }


}
