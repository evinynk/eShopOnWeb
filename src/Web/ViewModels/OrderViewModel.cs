using BlazorShared.Enums;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.Web.ViewModels;

public class OrderViewModel
{
    private const int DEFAULT_STATUS = 0;
    public OrderViewModel()
    {
        Status = DEFAULT_STATUS;
    }

    public int OrderNumber { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public Address? ShippingAddress { get; set; }
    public OrderStatus Status { get; set; }
}
