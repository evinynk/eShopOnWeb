using BlazorShared.Enums;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderUpdateStatusRequest : BaseRequest
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}
