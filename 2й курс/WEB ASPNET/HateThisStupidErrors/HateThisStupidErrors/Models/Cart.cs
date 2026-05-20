using System;
using System.Collections.Generic;

namespace HateThisStupidErrors.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }


}
