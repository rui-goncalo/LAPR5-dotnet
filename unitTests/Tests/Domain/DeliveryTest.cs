using System;
using System.Data;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Warehouses;
using NUnit.Framework;

namespace unitTests.Tests.Domain;

public class DeliveryTest
{
    [Test]
    public void Create_Valid_Delivery()
    {
        string deliveryId = "123";
        string warehouseId = "123";
        string deliveryDate = "delivery1";
        string mass = "12";
        string loadTime = "2";
        string unloadTime = "4";

        var delivery = new Delivery(new DeliveryId(deliveryId),new WarehouseId(warehouseId) ,new DeliveryDate(deliveryDate), new Mass(mass), new Time(loadTime), new Time(unloadTime));

        Assert.True(delivery.GetType().Equals(new Delivery().GetType()));
    }

    [Test]
    public void Create_InValid_Delivery_Wrong_DeliveryDate()
    {
        string deliveryId = "123";
        string warehouseId = "123";
        string deliveryDate = "";
        string mass = "12";
        string loadTime = "2";
        string unloadTime = "4";

        Assert.Throws<BusinessRuleValidationException>(() => new Delivery(new DeliveryId(deliveryId),new WarehouseId(warehouseId) ,new DeliveryDate(deliveryDate), new Mass(mass), new Time(loadTime), new Time(unloadTime)));
    }

    [Test]
    public void Create_InValid_Delivery_Wrong_Mass()
    {
        string deliveryId = "123";
        string warehouseId = "123";
        string deliveryDate = "delivery1";
        string mass = null;
        string loadTime = "2";
        string unloadTime = "4";

        Assert.Throws<BusinessRuleValidationException>(() => new Delivery(new DeliveryId(deliveryId),new WarehouseId(warehouseId) ,new DeliveryDate(deliveryDate), new Mass(mass), new Time(loadTime), new Time(unloadTime)));
    }

    [Test]
    public void Create_InValid_Delivery_Wrong_LoadTime_UnloadTime()
    {
        string deliveryId = "123";
        string warehouseId = "123";
        string deliveryDate = "delivery1";
        string mass = "12";
        string loadTime = null;
        string unloadTime = "4";

        Assert.Throws<BusinessRuleValidationException>(() => new Delivery(new DeliveryId(deliveryId),new WarehouseId(warehouseId) ,new DeliveryDate(deliveryDate), new Mass(mass), new Time(loadTime), new Time(unloadTime)));
    }
}