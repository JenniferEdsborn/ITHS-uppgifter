using Films.Database.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Films.Database.Entities;

public class Producer : IEntity
{
    public int ID { get; set; }
    [MaxLength(50), Required]
    public string Name { get; set; }
}
