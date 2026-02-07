namespace WarehouseManagement.Shared.Kernel;

public interface ISoftDeletable
{
    bool IsDeleted { get; }
    DateTime? DeletedAtUtc { get; }
}