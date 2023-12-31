using Data.Repository;
using Models;
using Models.DTOs;
using Models.DTOs.Create;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public List<Order> GetAllOrdersAsync()
    {
        return _orderRepository.GetAllOrdersAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await _orderRepository.GetOrderByIdAsync(orderId);
    }

    public async Task<Guid> AddOrderAsync(CreateOrderDto createOrderDto)
    {
        var orderEntity = _mapper.Map<Order>(createOrderDto);

        orderEntity.OrderDate = DateTime.Now;

        var orderId = await _orderRepository.AddOrderAsync(orderEntity);

        return orderId;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        if (order.OrderId == Guid.Empty)
        {
            throw new ArgumentException("Order Id cannot be empty");
        }

        var existingOrder = await _orderRepository.GetOrderByIdAsync(order.OrderId);
        if (existingOrder == null)
        {
            throw new ArgumentException($"Order with id {order.OrderId} does not exist");
        }


        await _orderRepository.UpdateOrderAsync(order);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        await _orderRepository.DeleteOrderAsync(orderId);
    }
}