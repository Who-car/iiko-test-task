using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities;

public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }
}