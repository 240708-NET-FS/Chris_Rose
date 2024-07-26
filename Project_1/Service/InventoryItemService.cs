using Project_1.DAO;
using Project_1.Entities;

namespace Project_1.Service;

public class InventoryItemService : IService<InventoryItem> {

    private readonly InventoryItemDAO _inventoryDAO;

    public InventoryItemService (InventoryItemDAO invetoryDAO) {
        _inventoryDAO = invetoryDAO;
    }

    public void Create(InventoryItem item) {
        _inventoryDAO.Create(item);
    }

    public void Delete(InventoryItem item) {
        _inventoryDAO.Delete(item);
    }

    public ICollection<InventoryItem> GetAll() {
        return _inventoryDAO.GetAll();
    }

    public InventoryItem? GetById(int Id) {
        return _inventoryDAO.GetById(Id);
    }

    public void Update(InventoryItem item) {
        _inventoryDAO.Update(item);
    }
}