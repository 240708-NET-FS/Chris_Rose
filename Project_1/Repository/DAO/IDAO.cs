namespace Project_1.DAO;

public interface IDAO<T> {

    public void Create(T item);

    public T? GetById(int ID);

    public ICollection<T> GetAll();

    public void Update(T newItem);

    public void Delete(T item);
}