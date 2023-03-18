using Films.Database.Interfaces;

namespace Films.Database.Entities;

public class FilmGenre : IReferenceEntity
{
    public int FilmID { get; set; }
    public int GenreID { get; set; }

    public Film? Film { get; set; }
    public Genre? Genre { get; set; }
}
