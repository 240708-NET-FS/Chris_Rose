using Project_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project_1.DAO;

public class OrderedItemDAO : IDAO<OrderedItem> {

    private ApplicationDbContext _context;

    public OrderedItemDAO(ApplicationDbContext context) {
        _context = context;
    }
    
    public void Create(OrderedItem i) {
        _context.OrderedItems.Add(i);
        _context.SaveChanges();
    }

    public void Delete(OrderedItem i) {
        _context.OrderedItems.Remove(i);
        _context.SaveChanges();
    }

    public ICollection<OrderedItem> GetAll(){
        List<OrderedItem> i = _context.OrderedItems.ToList();
        return i;
    }

    public OrderedItem GetById(int ID) {
        OrderedItem? i = _context.OrderedItems
                            .FirstOrDefault(oi => oi.product_id == ID);
        return i;
    }

    public void Update(OrderedItem newOrderedItem) {
        OrderedItem? originalOrderedItem = _context.OrderedItems.FirstOrDefault(oi => oi == newOrderedItem);

        if (originalOrderedItem != null) {
            originalOrderedItem.product_name = newOrderedItem.product_name;
            originalOrderedItem.price = newOrderedItem.price;
            originalOrderedItem.last_ordered = newOrderedItem.last_ordered;

            _context.OrderedItems.Update(originalOrderedItem);
            _context.SaveChanges();
        }
    }
}
