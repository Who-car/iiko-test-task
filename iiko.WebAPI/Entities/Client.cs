namespace WebAPI.Entities;

public class Client : BaseEntity
{
    public string Username { get; set; }
    public Guid SystemId { get; set; }
}