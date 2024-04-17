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


public class OrderListEndpoint : IEndpoint<IResult, OrderListRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;
    public OrderListEndpoint(IUriComposer uriComposer,IMapper mapper)
    {
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    public async void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders",
           async (IRepository<Order> orderRepository) =>
           {
               return await HandleAsync(new OrderListRequest(), orderRepository);
           })
          .Produces<OrderListResponse>()
          .WithTags("OrderEndpoints");
    }


    public async Task<IResult> HandleAsync(OrderListRequest request, IRepository<Order> order)
    {
        await Task.Delay(1000);
        var response = new OrderListResponse(request.CorrelationId());
        var orderSpec = new OrderSpecification();
        var orders = await order.ListAsync(orderSpec);
        response.Orders.AddRange(orders.Select(_mapper.Map<OrderDto>));

        return Results.Ok(response);
    }
}
