using Films.Database.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Films.Database.Entities;

public class Film : IEntity
{
    public int ID { get; set; }
    [MaxLength(50), Required]
    public string Title { get; set; }
    public DateTime Released { get; set; }
    public int ProducerID { get; set; }

    public Producer? Producer { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
}
