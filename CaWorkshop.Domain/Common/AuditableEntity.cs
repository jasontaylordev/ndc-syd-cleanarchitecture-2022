namespace CaWorkshop.Domain.Common;

public abstract class AuditableEntity
{
    public string CreatedBy { get; set; } = string.Empty;

    public DateTime CreatedUtc { get; set; }

    public string LastModifiedBy { get; set; } = string.Empty;

    public DateTime LastModifiedUtc { get; set; }
}