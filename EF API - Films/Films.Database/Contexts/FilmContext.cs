using Films.Database.Entities;

namespace Films.Database.Contexts;

public class FilmContext : DbContext
{
	public DbSet<Film> Films => Set<Film>();
	public DbSet<Producer> Producers => Set<Producer>();
	public DbSet<Genre> Genres => Set<Genre>();
	public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();

	public FilmContext(DbContextOptions<FilmContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<FilmGenre>()
			.HasKey(fg => new { fg.FilmID, fg.GenreID });
		//SeedData(builder);
	}

	private void SeedData (ModelBuilder builder)
	{
		var producers = new List<Producer>() 
		{ 
			new Producer{ ID = 1, Name = "Peter Jackson" },
			new Producer{ ID = 2, Name = "Warner Bros."},
			new Producer{ ID = 3, Name = "Buttercup Films Ltd."}
		};

		var genres = new List<Genre>()
		 {
			 new Genre{ ID = 1, GenreName = "Fantasy"},
			 new Genre{ ID = 2, GenreName = "Animated"},
			 new Genre{ ID = 3, GenreName = "Adventure"},
			 new Genre{ ID = 4, GenreName = "Action"},
			 new Genre{ ID = 5, GenreName = "Romance"}
		 };

		var filmGenres = new List<FilmGenre>()
		{
			new FilmGenre{FilmID = 1, GenreID = 1},
			new FilmGenre{FilmID = 1, GenreID = 3},
			new FilmGenre{FilmID = 2, GenreID = 3},
			new FilmGenre{FilmID = 2, GenreID = 2},
			new FilmGenre{FilmID = 3, GenreID = 3},
			new FilmGenre{FilmID = 3, GenreID = 5},
			new FilmGenre{FilmID = 3, GenreID = 1}
		};

		var films = new List<Film>()
		{
			new Film{ ID = 1, Title = "Lord of the Rings", Released = new DateTime(2001,12,19), ProducerID = 1},
			new Film{ ID = 2, Title = "Lego Movie", Released = new DateTime(2014,02,14), ProducerID = 2},
			new Film{ ID = 3, Title = "The Princess Bride", Released = new DateTime(1988,10,14), ProducerID = 3}
		};

        builder.Entity<Producer>().HasData(producers);
		builder.Entity<Genre>().HasData(genres);
		builder.Entity<FilmGenre>().HasData(filmGenres);
        builder.Entity<Film>().HasData(films);
	}
}
