namespace WarehouseManagement.Shared.Kernel;

public interface IAuditable
{
    DateTime CreatedAtUtc { get; }
    DateTime? UpdatedAtUtc { get; }
}