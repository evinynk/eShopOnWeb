using System;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;


public class OrderChangeStatusEndpoint : IEndpoint<IResult, OrderUpdateStatusRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;
    public OrderChangeStatusEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/order-status",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async (OrderUpdateStatusRequest request, IRepository<ApplicationCore.Entities.OrderAggregate.Order> orderRepository) =>
            {
                return await HandleAsync(request, orderRepository);
            })
           .Produces<OrderUpdateStatusResponse>()
           .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(OrderUpdateStatusRequest request, IRepository<Order> orderRepository)
    {
        var response = new OrderUpdateStatusResponse(request.CorrelationId());

        var item = await orderRepository.GetByIdAsync(request.Id);
        if (item is null)
            return Results.NotFound();

        item.UpdateOrderStatus(request.Status);

        await orderRepository.UpdateAsync(item);

        OrderDto order = _mapper.Map<OrderDto>(item);
        response.Order = order;
        return Results.Ok(response);
    }

}
