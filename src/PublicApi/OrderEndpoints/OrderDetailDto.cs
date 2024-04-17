﻿using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDetailDto :OrderDto
{
    public List<OrderItem> OrderItems { get; set; }

}
