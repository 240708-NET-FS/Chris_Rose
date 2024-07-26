using System;
using System.Net;
using Azure.Core.Pipeline;
using Project_1.DAO;
using Project_1.Entities;
using Project_1.Service;

namespace Project_1.Controller;

public class InventoryItemController {
    private readonly InventoryItemService inventoryItemService;
    private readonly OrderedItemService orderedItemService;

    public InventoryItemController(InventoryItemService iService, OrderedItemService oService){
        inventoryItemService = iService;
        orderedItemService = oService;

    }

    // Adds inventory to the inventory list
    public void AddNewInventory() {
        Console.WriteLine("Please input the following information:");

        try {
            Console.Write("Id from Order List: ");
            int id = Convert.ToInt32(Console.ReadLine());
            OrderedItem o = orderedItemService.GetById(id);

            if (inventoryItemService.GetById(id) is not null) {
                Console.WriteLine("This is already in your inventory!");
            } else {
                Console.WriteLine($"How many {o.product_name} would you like?");
                int q = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(q);
                InventoryItem newInventory = new InventoryItem {
                    product_name = o.product_name,
                    quantity = q,
                    last_received = DateTime.Now.ToString("m/d/yyyy"),
                };
            inventoryItemService.Create(newInventory);
            }
        } catch (Exception e) {
            Console.WriteLine(e.StackTrace);
        }

    }

    // Reads all items in the inventory
    public List<string> getInventory() {
        ICollection<InventoryItem> items = inventoryItemService.GetAll();
        List<string> _items = [];
        foreach (InventoryItem i in items) {
            _items.Add(i.ToString());
        }
        return _items;
    }

    // Ordering more product from the vendor
    public void orderInventory() {

        try {
            Console.WriteLine("What would you like? (Please enter by product_id)");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"How much {orderedItemService.GetById(id)} would you like?");
            int q = Convert.ToInt32(Console.ReadLine());
            
            InventoryItem inventoryItem = new InventoryItem{
                    product_id = id,
                    product_name = inventoryItemService.GetById(id).product_name,
                    quantity = q + inventoryItemService.GetById(id).quantity,
                    last_received = DateTime.Now.ToString("m/d/yyyy"),
                    ordered_item = null
            };
            inventoryItemService.Update(inventoryItem);
        } catch {
            Console.WriteLine("You don't have that item yet");
        }
    }

    public void discontinue() {
        Console.WriteLine("Which item would you like to discontinue? (Please enter the items id)");
        try {
            int id = Convert.ToInt32(Console.ReadLine());
            InventoryItem? dItem = inventoryItemService.GetById(id);
            if (dItem != null) {
                inventoryItemService.Delete(dItem);
            } else {
                Console.WriteLine("That item is not in your inventory");
            }
        } catch {
            Console.WriteLine("No item has that id");
        }

    }

}