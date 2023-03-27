using NodaTime;

namespace ChainOfResponsibility.Implementation.Data.Models;

public abstract class EntityBase
{
    public int Id { get; set; }
    public string? CreatedBy { get; set; }
    public LocalDateTime? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public LocalDateTime? ModifiedOn { get; set; }
}