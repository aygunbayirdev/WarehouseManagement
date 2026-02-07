namespace WarehouseManagement.Modules.Inventory.Domain;

public enum TrackingStrategy
{
    None = 0, // Standart stok (sadece adet)
    Serial = 1, // Seri Numaralı (Her ürün tekil)
    Lot = 2 // Parti/Lot Takibi
}