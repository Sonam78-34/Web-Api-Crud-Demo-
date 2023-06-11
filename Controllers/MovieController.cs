using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCrudApi.Context;
using MovieCrudApi.Models.Movie;

namespace MovieCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly MovieApiDbContext context;

        public MovieController(MovieApiDbContext apiDbcontext)
        {
            context = apiDbcontext;

        }

        //toget the movies
        [HttpGet]

        public IActionResult GetMovies()
        {
            var movie = context.movies.ToList();
            if (movie == null)
            {
                return NotFound("Movie not found in database");
            }
            return Ok(movie);
        }


        //to Add the movie
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            context.movies.Add(movie);
            context.SaveChanges();
            return Ok("Movie added successfully");
        }

        //to get movie by id
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id) 
        {
            var movie = context.movies.Find(id);
            if(movie == null) 
            {
                return NotFound("Id is not valid, Enter valid id");
            }
            return Ok(movie);
        }

        //toupdate the movie
        [HttpPut]
        public IActionResult UpdateMovie(Movie movie)
        { 
            if(movie == null || movie.MovieId==0)
            {
                return BadRequest("Movie Update is not possible for invalid data");
            }

            var mov = context.movies.Find(movie.MovieId);
            if(movie == null)
            {
                return NotFound("Movie doesn't exist in the database");
            }

            //intialise the updated value
            mov.Title = movie.Title;
            mov.Description = movie.Description;
            mov.Rating = movie.Rating;
            mov.Duration = movie.Duration;

            context.SaveChanges();
            return Ok("Moive updated Successfully");
        
        }

        //to delete
        [HttpDelete]
        public IActionResult DeleteMovie(int id) 
        { 
            var movie= context.movies.Find(id);
            if(movie == null)
            {
                return NotFound("Movie Id Does Not Exist");
            }
            context.movies.Remove(movie);
            context.SaveChanges();
            return Ok("Deleted successfully");
        }




    }

}
