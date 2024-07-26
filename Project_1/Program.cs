using System.Reflection.Metadata;
using Project_1.Entities;
using Project_1.DAO;
using System.Runtime.InteropServices;
using Project_1.Service;
using Project_1.Controller;

namespace Project_1;

public class Program {

    public static void Main(string[] args) {
        
        using (var context = new ApplicationDbContext()) {
            OrderedItemDAO oiDAO = new OrderedItemDAO(context);
            InventoryItemDAO iiDAO = new InventoryItemDAO(context);

            OrderedItemService oiService = new OrderedItemService(oiDAO);
            InventoryItemService iiService = new InventoryItemService(iiDAO);

            OrderedItemController orderController =new OrderedItemController(oiService);
            InventoryItemController inventoryController = new InventoryItemController(iiService, oiService);

            Console.WriteLine("Welcome to the GroceryApp! What would you like to do today?");

            while (true) {
                Console.WriteLine("1) Add new inventory\n2) See order list\n3) Get inventory numbers\n4) Order more product\n5) Discontinue a product\n6) Exit");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option) {

                    // Add inventory
                    case 1:
                        inventoryController.AddNewInventory();
                        break;

                    // See orderable products
                    case 2:
                        List<string> orderList = orderController.getOrderList();
                        foreach(string s in orderList) {
                            Console.WriteLine(s);
                        }
                        break;

                    // Get Numbers
                    case 3:
                        List<string> inventoryList = inventoryController.getInventory();
                        foreach(string s in inventoryList) {
                            Console.WriteLine(s);
                        }
                        break;

                    // Order product
                    case 4:
                        inventoryController.orderInventory();
                        break;
                    
                    // Discontinue
                    case 5:
                        inventoryController.discontinue();
                        break;

                    // Exit
                    case 6:
                        Environment.Exit(1);
                        break;

                    // Try again
                    default:
                        Console.WriteLine("Please choose one of the listed options");
                        break;
                }
            }
        }
    }
}