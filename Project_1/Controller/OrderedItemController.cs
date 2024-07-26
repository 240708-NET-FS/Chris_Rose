using Project_1.DAO;
using Project_1.Entities;
using Project_1.Service;

namespace Project_1.Controller;

public class OrderedItemController {
    private OrderedItemService orderedItemService;

    public OrderedItemController(OrderedItemService service){
        orderedItemService = service;
    }

    // Get order list
    public List<string> getOrderList() {
        ICollection<OrderedItem> items = orderedItemService.GetAll();
        List<string> _items = [];
        foreach (OrderedItem i in items) {
            _items.Add(i.ToString());
        }
        return _items;
    }

}