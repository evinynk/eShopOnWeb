using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<CatalogItemService> _logger;
    public OrderService(HttpService httpService,
        ILogger<CatalogItemService> logger)
    {       
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<Order> ApproveOrderStatus(Order order)
    {
        var changeOrderStatus = _httpService.HttpPut<OrderUpdateResponse>($"order-status", order);
        await Task.WhenAll(changeOrderStatus);
        var newOrder = changeOrderStatus.Result.Order;
        return newOrder;

    }
    public async Task<OrderDetail> GetById(int id)
    {
        var getOrder = _httpService.HttpGet<OrderDetailResponse>($"orders/" + id);
        await Task.WhenAll(getOrder);
        var order = getOrder.Result.Order;
        return order;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching orders from API.");

        var getorderList = _httpService.HttpGet<OrderListResponse>($"orders");
        await Task.WhenAll(getorderList);
        var items = getorderList.Result.Orders;
        return items;
    }
}
