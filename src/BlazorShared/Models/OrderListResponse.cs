﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class OrderListResponse
{
    public List<Order> Orders { get; set; } = new List<Order>();
}
