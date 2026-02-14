using WarehouseManagement.Shared.Kernel;

namespace WarehouseManagement.Modules.Inventory.Domain;

public enum ReceiptStatus
{
    Draft = 1, // Taslak (henüz stoklara etki etmez)
    Completed = 2, // Tamamlandı (Stoklar arttı)
    Cancelled = 3 // İptal
}

public class Receipt : BaseEntity
{
    public Guid SupplierId { get; private set; }
    public DateTime ReceiptDate { get; private set; }
    public string ReferenceNumber { get; private set; } // İrsaliye No
    public ReceiptStatus Status { get; private set; }

    // Navigation Property (Bir fişin birden çok satırı olur)
    private readonly List<ReceiptLine> _lines = new();
    public IReadOnlyCollection<ReceiptLine> Lines => _lines.AsReadOnly();

    public Receipt(Guid supplierId, string referenceNumber)
    {
        Id = Guid.NewGuid();
        SupplierId = supplierId;
        ReferenceNumber = referenceNumber;
        ReceiptDate = DateTime.UtcNow;
        Status = ReceiptStatus.Draft;
    }

    // Fişe satır ekleme metodu (Domain Logic)
    public void AddLine(Guid productId, decimal quantity)
    {
        // Validasyon: Miktar 0 veya eksi olamaz
        if (quantity <= 0)
        {
            throw new ArgumentException("Miktar 0'dan büyük olmalıdır.");
        }

        var line = new ReceiptLine(Id, productId, quantity);
        _lines.Add(line);
    }

    public void Complete()
    {
        // Validasyon: Hiç satır yoksa tamamlanamaz
        if (!_lines.Any())
        {
            throw new InvalidOperationException("Satır olmayan fiş tamamlanamaz.");
        }

        Status = ReceiptStatus.Completed;
    }
}

