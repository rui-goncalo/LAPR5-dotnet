using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Moq;
using NUnit.Framework;

namespace unitTests.Tests.Domain;
public class WarehouseServiceTest
{
    private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private Mock<IWarehouseRepository> _repoMock = new Mock<IWarehouseRepository>();
    private const string WarehouseId1 = "123";
    private const string WarehouseId2 = "321";
    private const string WarehouseId3 = "456";

    public List<Warehouse> Warehouses()
    {
        string warehouseId = "123";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        string warehouseId2 = "321";
        string address2 = "address2";
        string designation2 = "designation2";
        string geoCoords2 = "geoCoord2";
        return new List<Warehouse>
        {
            new Warehouse(new WarehouseId(warehouseId), new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords)),
            new Warehouse(new WarehouseId(warehouseId2), new WarehouseAddress(address2), new WarehouseDesignation(designation2), new WarehouseGeoCoord(geoCoords2))

        };
    }

    public List<WarehouseDto> WarehousesDTO()
    {
        string warehouseId = "123";
        string address = "address1";
        string designation = "designation1";
        string geoCoords = "geoCoord1";

        string warehouseId2 = "321";
        string address2 = "address2";
        string designation2 = "designation2";
        string geoCoords2 = "geoCoord2";
        var wh = new Warehouse(new WarehouseId(warehouseId), new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));

        var wh1 = new Warehouse(new WarehouseId(warehouseId2), new WarehouseAddress(address2), new WarehouseDesignation(designation2), new WarehouseGeoCoord(geoCoords2));

        return new List<WarehouseDto>
        {
            new WarehouseDto { Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords },
            new WarehouseDto {Id = wh1.Id.AsGuid(), WarehouseId = wh1.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh1.WarehouseAddress.wh_address, WarehouseDesignation = wh1.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh1.WarehouseGeoCoord.wh_geoCoords }
        };
    }

    public Warehouse Warehouse()
    {
        string warehouseId = "456";
        string address = "address3";
        string designation = "designation3";
        string geoCoords = "geoCoord3";
        return new Warehouse(new WarehouseId(warehouseId), new WarehouseAddress(address), new WarehouseDesignation(designation), new WarehouseGeoCoord(geoCoords));
    }

    [Test]
    public async Task TestInactivateWarehouse()
    {
        var warehouse = Warehouse();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseId.WarehouseIdentifier))
            .ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.InactivateAsync(warehouse.WarehouseId.WarehouseIdentifier);
        var actualActive = await _service.CheckActivateAsync(warehouse.WarehouseId.WarehouseIdentifier);
        bool expected = warehouse.Active;


        Assert.AreNotEqual(actualActive, expected);
    }


    [Test]
    public async Task TestGetAllAsync()
    {
        var warehouseList = Warehouses();
        this._repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(warehouseList);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var list = await _service.GetAllAsync();


        Assert.AreEqual(WarehouseId1, list[0].WarehouseId);
        Assert.AreEqual(WarehouseId2, list[1].WarehouseId);
        Assert.AreEqual(2, list.Count);
    }

    [Test]
    public async Task TestGetByWarehouseIdAsync()
    {
        var warehouse = Warehouse();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseId.WarehouseIdentifier))
            .ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.GetByWarehouseIdAsync(warehouse.WarehouseId.WarehouseIdentifier);

        Assert.AreEqual(warehouse.WarehouseId.WarehouseIdentifier, get_warehouse.WarehouseId);
    }

    [Test]
    public async Task TestPostAsync()
    {
        var wh = Warehouse();
        this._repoMock.Setup(repo => repo.AddAsync(wh)).ReturnsAsync(wh);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.AddAsync(new CreatingWarehouseDto{ WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords });


        Assert.AreEqual(WarehouseServiceTest.WarehouseId3, get_warehouse.WarehouseId);
    }

}