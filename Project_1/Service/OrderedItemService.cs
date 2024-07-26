using Project_1.DAO;
using Project_1.Entities;

namespace Project_1.Service;

public class OrderedItemService : IService<OrderedItem> {

    private readonly OrderedItemDAO _orderDAO;

    public OrderedItemService(OrderedItemDAO orderDAO) {
        _orderDAO = orderDAO;
    }

    public void Create(OrderedItem item)
    {
        _orderDAO.Create(item);
    }

    public void Delete(OrderedItem item) {
        _orderDAO.Delete(item);
    }

    public ICollection<OrderedItem> GetAll() {
        return _orderDAO.GetAll();
    }

    public OrderedItem GetById(int Id) {
        return _orderDAO.GetById(Id);
    }

    public void Update(OrderedItem item) {
        _orderDAO.Update(item);
    }
}