﻿namespace MovieCrudApi.Models.Movie
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int Rating { get; set; }

        public int Duration { get; set;}

    }
}
