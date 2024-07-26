namespace Project_1.Tests;
using System.Reflection.Metadata;
using Project_1.Entities;
using Project_1.DAO;
using System.Runtime.InteropServices;
using Project_1.Service;
using Project_1.Controller;
using Microsoft.VisualBasic;

public class UnitTest1 {

            static ApplicationDbContext context = new ApplicationDbContext();
            static OrderedItemDAO oiDAO = new OrderedItemDAO(context);
            static InventoryItemDAO iiDAO = new InventoryItemDAO(context);
            static OrderedItemService oiService = new OrderedItemService(oiDAO);
            static InventoryItemService iiService = new InventoryItemService(iiDAO);
            OrderedItemController orderController =new OrderedItemController(oiService);
            InventoryItemController inventoryController = new InventoryItemController(iiService, oiService);

    [Fact]
    public void CanCreateNewInventory() {
        
        // Arrange
        InventoryItem item = new InventoryItem {
            product_id = 5,
            product_name = "bread",
            last_received = "01/01/1999",
            quantity = 12
        };

        // Act
        iiService.Create(item);
        InventoryItem created = iiService.GetById(item.product_id);

        // Assert
        Assert.Equal(item, created);

    }

    [Fact]
    public void CanUpdateInventory() {

        // Arrange
        InventoryItem toUpdate = new InventoryItem {
            product_id = 5,
            product_name = "bread",
            last_received = DateTime.Today.ToString(),
            quantity = 12
        };

        // Act
        iiService.Update(toUpdate);
        InventoryItem updated = iiService.GetById(5);

        // Assert
        Assert.Equal(toUpdate, updated);

    }

    [Fact]
    public void CanReadInventory() {

        // Arrange
        InventoryItem invA = new InventoryItem{
            product_id = 5,
            product_name = "bread",
            last_received = DateTime.Today.ToString(),
            quantity = 12
        };
        InventoryItem invB = new InventoryItem{
            product_id = 12,
            product_name = "milk",
            last_received = DateTime.Today.ToString(),
            quantity = 24
        };
        List<InventoryItem> expected = new List<InventoryItem> {invA, invB};

        // Act
        iiService.Create(invA);
        iiService.Create(invB);

        // Assert
        Assert.Equal(expected, iiService.GetAll());
    }

    [Fact]
    public void CanDeleteInventory() {

        // Arrange 
        InventoryItem invA = new InventoryItem{
            product_id = 5,
            product_name = "bread",
            last_received = DateTime.Today.ToString(),
            quantity = 12
        };

        // Act
        iiService.Create(invA);
        iiService.Delete(invA);

        // Assert
        Assert.DoesNotContain(invA, iiService.GetAll());
    }
}
