using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Service;
using NUnit.Framework;
using Moq;

namespace CoffeeShopApiTests;

using System;
using System.Collections.Generic;

[TestFixture]
public class OrderServiceTests
{
    private OrderService _orderService;
    private Mock<IOrderRepository> _orderRepositoryMock;
    private Mock<IMapper> _mapperMock;

    [SetUp]
    public void Setup()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _mapperMock = new Mock<IMapper>();
        _orderService = new OrderService(_orderRepositoryMock.Object, _mapperMock.Object);
    }


    [Test]
    public void AddOrderAsync_WithValidData_ShouldReturnOrderId()
    {
        var createOrderDto = new CreateOrderDto
        {
        };

        var newOrder = new Order
        {
            OrderId = Guid.NewGuid(),
        };

        _mapperMock.Setup(mapper => mapper.Map<Order>(createOrderDto)).Returns(newOrder);
        _orderRepositoryMock.Setup(repo => repo.AddOrderAsync(newOrder)).ReturnsAsync(newOrder.OrderId);

        var result = _orderService.AddOrderAsync(createOrderDto).Result;

        Assert.That(result, Is.EqualTo(newOrder.OrderId));
        _orderRepositoryMock.Verify(repo => repo.AddOrderAsync(newOrder), Times.Once);
    }


    [Test]
    public void GetOrderByIdAsync_WithValidOrderId_ShouldReturnOrder()
    {
        var orderId = Guid.NewGuid();
        var expectedOrder = new Order
        {
            OrderId = orderId,
        };

        _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(orderId)).ReturnsAsync(expectedOrder);

        var result = _orderService.GetOrderByIdAsync(orderId).Result;

        Assert.That(result, Is.EqualTo(expectedOrder));
    }
}