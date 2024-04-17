using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Enums;

namespace BlazorShared.Models;
public class OrderUpdateStatusRequest
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}
