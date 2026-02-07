namespace WarehouseManagement.Shared.Kernel;

public abstract class BaseEntity : IAuditable, ISoftDeletable
{
    public int Id { get; protected set; }

    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; private set; }

    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAtUtc { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public virtual void Delete()
    {
        if (IsDeleted) return;

        IsDeleted = true;
        DeletedAtUtc = DateTime.UtcNow;
        // İleride burada bir "EntityDeletedDomainEvent" de fırlatabiliriz!
    }

    public virtual void UndoDelete()
    {
        IsDeleted = false;
        DeletedAtUtc = null;
    }
}