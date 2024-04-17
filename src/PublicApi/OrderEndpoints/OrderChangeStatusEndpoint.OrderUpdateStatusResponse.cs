using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderUpdateStatusResponse : BaseResponse
{
    public OrderUpdateStatusResponse(Guid correlationId) : base(correlationId)
    {
    }

    public OrderUpdateStatusResponse()
    {
    }

    public OrderDto Order { get; set; }
}
