using System;
using System.Data;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using NUnit.Framework;

namespace unitTests.Tests.Domain;

public class WarehouseTest
{
    [Test]
    public void Create_Valid_Warehouse()
    {

        string warehouseId = "123";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        var warehouse = new Warehouse(new WarehouseId(warehouseId), new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        Assert.True(warehouse.GetType().Equals(new Warehouse().GetType()));
    }

    [Test]
    public void Create_InValid_Warehouse_Missing_Address()
    {
        string warehouseId = "123";
        string address ="";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        Assert.Throws<BusinessRuleValidationException>(() => new Warehouse (new WarehouseId(warehouseId),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords)));
    }

    [Test]
    public void Create_InValid_Warehouse_Missing_Designation()
    {
        string warehouseId = "123";
        string address ="address1";;
        string designation = "";
        string geoCoords = "geoCoord1";

        Assert.Throws<BusinessRuleValidationException>(() => new Warehouse(new WarehouseId(warehouseId), new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords)));
    }

    [Test]
    public void Create_InValid_Warehouse_Missing_GeoCoords()
    {
        string warehouseId = "123";
        string address ="address1";;
        string designation = "designation1";
        string geoCoords = "";

        Assert.Throws<BusinessRuleValidationException>(() => new Warehouse(new WarehouseId(warehouseId),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords)));
    }
}