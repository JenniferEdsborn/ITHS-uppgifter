using Films.Database.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Films.Database.Entities;

public class Genre : IEntity
{
    public int ID { get; set; }
    [MaxLength(50), Required]
    public string GenreName { get; set; }
    public virtual ICollection<Film>? Films { get; set; }
}
