namespace Project_1.Entities;

public class InventoryItem {

    public InventoryItem() {}

    public int product_id { get; set; }
    
    public string? product_name { get; set; }

    public int quantity { get; set; }

    public string? last_received { get; set; }

    public OrderedItem? ordered_item { get; set; }

    public override string ToString() {
        return $"{product_id} {product_name} {quantity}";
    }
}