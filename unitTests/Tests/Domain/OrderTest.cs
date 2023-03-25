using System;
using System.Data;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Orders;
using NUnit.Framework;

namespace unitTests.Tests.Domain;

public class OrderTest
{
    [Test]
    public void Create_Valid_Order()
    {
        string orderId = "123";
        string description = "description1";

        var order = new Order(new OrderId(orderId) ,new OrderDescription(description));

        Assert.True(order.GetType().Equals(new Order().GetType()));
    }

    [Test]
    public void Create_InValid_Order_Missing_Description()
    {
        string orderId = "123";
        string description = "";

        Assert.Throws<BusinessRuleValidationException>(() => new  Order(new OrderId(orderId),new OrderDescription(description)));
    }

}