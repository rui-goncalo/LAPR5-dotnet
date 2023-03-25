using System.Reflection.Metadata;
using DDDSample1.Controllers;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Warehouses;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;


namespace testProject.Tests.Controller;

public class DelieveryControllerTest
{
    [Test]
    public async void GetAll()
    {
        var driverServiceMock = new Mock<DeliveryService>();
        string deliveryId = "123";
        string warehouseId = "123";
        string deliveryDate = "20/11/2022";
        string mass = "1";
        string loadTime = "10";
        string unloadTime = "8";

        var dl = new Delivery(new DeliveryId(deliveryId),new WarehouseId(warehouseId) ,new DeliveryDate(deliveryDate), new Mass(mass), new Time(loadTime), new Time(unloadTime));

        var deliveryDto = new DeliveryDto { Id = dl.Id.AsGuid(), DeliveryId = dl.DeliveryId.DeliveryIdentifier, WarehouseId = dl.WarehouseId.WarehouseIdentifier ,DeliveryDate = dl.DeliveryDate.DelDate , Mass =dl.Mass.Mass1, LoadTime = dl.LoadTime.Time1, UnloadTime = dl.UnloadTime.Time1};

        var deliveryDtoList = new List<DeliveryDto> { deliveryDto };

        driverServiceMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryDtoList);

        var controller = new DeliveriesController(driverServiceMock.Object);

        var actual = await controller.GetAll();

        Assert.AreEqual(deliveryDtoList, actual.Value);
    }
    
    [Test]
    public async void GetByWarehouseId()
    {
        var driverServiceMock = new Mock<DeliveryService>();
        string deliveryId = "123";
        string warehouseId = "123";
        string deliveryDate = "20/11/2022";
        string mass = "1";
        string loadTime = "10";
        string unloadTime = "8";

        var dl = new Delivery(new DeliveryId(deliveryId),new WarehouseId(warehouseId) ,new DeliveryDate(deliveryDate), new Mass(mass), new Time(loadTime), new Time(unloadTime));

        var deliveryDto = new DeliveryDto { Id = dl.Id.AsGuid(), DeliveryId = dl.DeliveryId.DeliveryIdentifier, WarehouseId = dl.WarehouseId.WarehouseIdentifier ,DeliveryDate = dl.DeliveryDate.DelDate , Mass =dl.Mass.Mass1, LoadTime = dl.LoadTime.Time1, UnloadTime = dl.UnloadTime.Time1};
        
        driverServiceMock.Setup(_ => _.GetByDeliveryIdAsync(deliveryDto.DeliveryId)).ReturnsAsync(deliveryDto);

        var controller = new DeliveriesController(driverServiceMock.Object);

        var actual = await controller.GetByDeliveryId(deliveryId);

        Assert.AreEqual(deliveryDto, actual.Value);
    }

}