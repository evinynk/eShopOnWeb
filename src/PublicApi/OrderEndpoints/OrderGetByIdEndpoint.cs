using System;
using System.Linq;
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
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;


public class OrderGetByIdEndpoint : IEndpoint<IResult, GetByIdOrderRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;
    public OrderGetByIdEndpoint(IUriComposer uriComposer,IMapper mapper)
    {
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    public async void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders/{orderId}",
            async (int orderId, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(new GetByIdOrderRequest(orderId), orderRepository);
            })
            .Produces<GetByIdOrderResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(GetByIdOrderRequest request, IRepository<Order> order)
    {
        var response = new GetByIdOrderResponse(request.CorrelationId());
        var spesification = new OrderWithItemsByIdSpec(request.OrderId);
        var getOrder = await order.FirstOrDefaultAsync(spesification);
        if (getOrder is null)
            return Results.NotFound();

        response.Order = new OrderDetailDto
        {
            Id = getOrder.Id,
            OrderDate = getOrder.OrderDate,
            BuyerId = getOrder.BuyerId,
            OrderItems = getOrder.OrderItems.ToList(),
            Status = getOrder.Status,
            Total = getOrder.Total()
        };
        return Results.Ok(response);
    }
}
