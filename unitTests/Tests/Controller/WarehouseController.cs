using System.Collections.Generic;
using System.Reflection.Metadata;
using DDDSample1.Controllers;
using DDDSample1.Domain.Warehouses;
using Moq;
using NUnit.Framework;

namespace testProject.Tests.Controller;

public class WarehouseControllerTest
{
    [Test]
    public async void GetAll()
    {
        var driverServiceMock = new Mock<WarehouseService>();
        string id = "W123";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        var wh = new Warehouse(new WarehouseId(id),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var warehouseDto = new WarehouseDto { Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };

        var warehouseDtoList = new List<WarehouseDto> { warehouseDto };


        driverServiceMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseDtoList);

        var controller = new WarehousesController(driverServiceMock.Object);

        var actual = await controller.GetAll();

        Assert.AreEqual(warehouseDtoList, actual.Value);
    }
    
    [Test]
    public async void GetByWarehouseId()
    {
        var driverServiceMock = new Mock<WarehouseService>();
        string id = "W122";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        var wh = new Warehouse(new WarehouseId(id),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var warehouseDto = new WarehouseDto { Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };
        
        driverServiceMock.Setup(_ => _.GetByWarehouseIdAsync(warehouseDto.WarehouseId)).ReturnsAsync(warehouseDto);

        var controller = new WarehousesController(driverServiceMock.Object);

        var actual = await controller.GetByWarehouseId(id);

        Assert.AreEqual(warehouseDto, actual.Value);
    }

    [Test]
    public async void InactivateWarehouse()
    {
        var driverServiceMock = new Mock<WarehouseService>();
        string id = "W122";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        var wh = new Warehouse(new WarehouseId(id),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var warehouseDto = new WarehouseDto { Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };
        
        driverServiceMock.Setup(_ => _.InactivateAsync(warehouseDto.WarehouseId)).ReturnsAsync(warehouseDto);

        var controller = new WarehousesController(driverServiceMock.Object);

        var actual = await controller.GetByWarehouseId(id);

        Assert.AreNotEqual(warehouseDto, actual.Value);
    }

    [Test]
    public async void Create()
    {
        var driverServiceMock = new Mock<WarehouseService>();
        string id = "W122";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";
    
        var wh = new Warehouse(new WarehouseId(id),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var CwarehouseDto = new CreatingWarehouseDto { WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };
    
        var warehouseDto = new WarehouseDto {Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };

        driverServiceMock.Setup (_ => _.AddAsync (CwarehouseDto)).ReturnsAsync (warehouseDto);
    
        var controller = new WarehousesController(driverServiceMock.Object);
    
        var actual = await controller.Create(CwarehouseDto);
    
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Test]
    public async void Update()
    {
        //only updating address
        var driverServiceMock = new Mock<WarehouseService>();
        string id = "W122";
        string address = "address1";
        string address2 = "address2";
        string designation = "designation1";
        string geoCoords = "geoCoord1";
    
        var wh = new Warehouse(new WarehouseId(id),new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var warehouseDto = new WarehouseDto {Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };

        
        var wh1 = new Warehouse(new WarehouseId(id),new WarehouseAddress(address2), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var warehouseDto1 = new WarehouseDto {Id = wh1.Id.AsGuid(), WarehouseId = wh1.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh1.WarehouseAddress.wh_address, WarehouseDesignation = wh1.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh1.WarehouseGeoCoord.wh_geoCoords };

        
        driverServiceMock.Setup(_ => _.GetByWarehouseIdAsync(warehouseDto.WarehouseId)).ReturnsAsync(warehouseDto);
    
        var controller = new WarehousesController(driverServiceMock.Object);
    
        var actual = await controller.Update(id, warehouseDto1);
    
        Assert.AreEqual(warehouseDto, actual.Value);
    }
    
}