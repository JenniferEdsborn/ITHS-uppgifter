using System.ComponentModel.DataAnnotations;

namespace Films.Common.DTOs;

public class FilmDTO
{
    public int ID { get; set; }
    [MaxLength(50), Required]
    public string Title { get; set; }
    public DateTime Released { get; set; }
    public int ProducerID { get; set; }

}


//public class FilmUpdateDTO : FilmInsertDTO
//{
//    public int ID { get; set; }

//}

//public class FilmInsertDTO
//{
//    [MaxLength(50), Required]
//    public string Title { get; set; }
//    public DateTime Released { get; set; }
//    public int ProducerID { get; set; }

//}