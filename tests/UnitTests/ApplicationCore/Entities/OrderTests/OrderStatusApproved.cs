using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Enums;
using Microsoft.eShopWeb.UnitTests.Builders;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.OrderTests;
public class OrderStatusApproved
{
    private OrderStatus _status = OrderStatus.approved;

    [Fact]
    public void IsOrderStatusApprove()
    {
        var order = new OrderBuilder().WithNoItems();
        order.UpdateOrderStatus(_status);
        Assert.Equal(order.Status, _status);
    }
}
