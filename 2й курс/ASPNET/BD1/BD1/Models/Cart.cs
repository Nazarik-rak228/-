using System;
using System.Collections.Generic;

namespace BD1.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }


}
