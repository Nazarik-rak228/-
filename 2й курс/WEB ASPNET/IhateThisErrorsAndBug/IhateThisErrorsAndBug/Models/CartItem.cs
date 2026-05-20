using IhateThisErrorsAndBug.validation;
using System;
using System.Collections.Generic;

namespace IhateThisErrorsAndBug.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    [NoOptBaying]
    public int Quantity { get; set; }


}
