using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;
public interface IOrderService
{
    Task<OrderDetail> GetById(int id);
    Task<List<Order>> List();
    Task<Order> ApproveOrderStatus(Order order);

}
