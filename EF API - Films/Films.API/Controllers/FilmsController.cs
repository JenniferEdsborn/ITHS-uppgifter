using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Films.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        
        private readonly IDbService _db;

        public FilmsController(IDbService db)
        {
            _db = db;
        }

        // GET: api/<FilmsController>
        [HttpGet]
        public async Task<IResult> Get() // IResult för att få med Result-code
        {
            var films = await _db.GetAsync<Film, FilmDTO>();
            return Results.Ok(films); // Result = 200 OK
        }

        // GET api/<FilmsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var film = await _db.SingleAsync<Film, FilmDTO>(f => f.ID.Equals(id));
            return Results.Ok(film);
        }

        // POST api/<FilmsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmDTO dto)
        {

        }

        // PUT api/<FilmsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}