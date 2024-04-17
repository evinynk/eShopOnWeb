using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class OrderDetailResponse
{
    public OrderDetail Order { get; set; } = new OrderDetail();
}
