using BlazorShared.Enums;
using BlazorShared.Models;
using System.Collections.Generic;
using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public OrderStatus Status { get; set; }
}
