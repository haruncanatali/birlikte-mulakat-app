namespace Birlikte.Domain.Entities;

public class Cart : BaseEntity
{
    public List<Order> Orders { get; set; }
}