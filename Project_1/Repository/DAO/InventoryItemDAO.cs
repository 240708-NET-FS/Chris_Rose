using Project_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project_1.DAO;

public class InventoryItemDAO : IDAO<InventoryItem> {

    private ApplicationDbContext _context;

    public InventoryItemDAO(ApplicationDbContext context) {
        _context = context;
    }
    
    public void Create(InventoryItem i) {
        _context.InventoryItems.Add(i);
        _context.SaveChanges();
    }

    public void Delete(InventoryItem i) {
        _context.InventoryItems.Remove(i);
        _context.SaveChanges();
    }

    public ICollection<InventoryItem> GetAll(){
        List<InventoryItem> i = _context.InventoryItems.ToList();
        return i;
    }

    public InventoryItem GetById(int ID) {
        InventoryItem? i = _context.InventoryItems
                            .FirstOrDefault(ii => ii.product_id == ID);
        return i;
    }

    public void Update(InventoryItem newInventoryItem) {
        InventoryItem? originalInventoryItem = _context.InventoryItems.FirstOrDefault(ii => ii == newInventoryItem);

        if (originalInventoryItem != null) {
            originalInventoryItem.product_name = newInventoryItem.product_name;
            originalInventoryItem.quantity = newInventoryItem.quantity;
            originalInventoryItem.last_received = newInventoryItem.last_received;

            _context.InventoryItems.Update(originalInventoryItem);
            _context.SaveChanges();
        }
    }

}