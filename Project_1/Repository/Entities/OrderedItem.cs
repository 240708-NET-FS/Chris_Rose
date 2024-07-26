namespace Project_1.Entities;

public class OrderedItem {

    public OrderedItem() {}

    public int product_id { get; set; }

    public required string product_name { get; set; }

    public required string last_ordered { get; set; }

    public double price { get; set; }

    public InventoryItem? inventory_item { get; set; }

    public override string ToString() {
        return $"{product_id} {product_name} {price}";
    }
}