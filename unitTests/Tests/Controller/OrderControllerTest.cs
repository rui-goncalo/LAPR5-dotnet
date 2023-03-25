using System.Collections.Generic;
using System.Reflection.Metadata;
using DDDSample1.Controllers;
using DDDSample1.Domain.Orders;
using Moq;
using NUnit.Framework;

namespace testProject.Tests.Controller;

public class OrderControllerTest
{
    [Test]
    public async void GetAll()
    {
        var driverServiceMock = new Mock<OrderService>();
        string orderId = "123";
        string description = "description1";

        var or = new Order(new OrderId(orderId) ,new OrderDescription(description));

        var orderDto = new OrderDto { Id = or.Id.AsGuid(), OrderId = or.OrderId.OrderIdentifier, OrderDescription = or.Description.description };

        var orderDtoList = new List<OrderDto> { orderDto };

        driverServiceMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(orderDtoList);

        var controller = new OrdersController(driverServiceMock.Object);

        var actual = await controller.GetAll();

        Assert.AreEqual(orderDtoList, actual.Value);
    }
    
    [Test]
    public async void GetByWarehouseId()
    {
        var driverServiceMock = new Mock<OrderService>();
        string orderId = "123";
        string description = "description1";

        var or = new Order(new OrderId(orderId) ,new OrderDescription(description));

        var orderDto = new OrderDto { Id = or.Id.AsGuid(), OrderId = or.OrderId.OrderIdentifier, OrderDescription = or.Description.description };
        
        driverServiceMock.Setup(_ => _.GetByOrderIdAsync(orderDto.OrderId)).ReturnsAsync(orderDto);

        var controller = new OrdersController(driverServiceMock.Object);

        var actual = await controller.GetByOrderId(orderId);

        Assert.AreEqual(orderDto, actual.Value);
    }

}