using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWatchlist.DTOs
{
    public class MotionPictureDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public string? ImagePath { get; set; }
        public string? WatchedEpisodes { get; set; }    
        public string? EpisodeCount { get; set; }
    }
}
