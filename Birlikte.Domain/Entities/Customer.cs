namespace Birlikte.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public long CartId { get; set; }

    public Cart Cart { get; set; }
}