using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Enums;

namespace BlazorShared.Models;
public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }         
    public string BuyerId { get;  set; }
    public DateTimeOffset OrderDate { get; set; }
    public OrderAddress ShipToAddress { get; set; }
    public OrderStatus Status { get; set; }

}
