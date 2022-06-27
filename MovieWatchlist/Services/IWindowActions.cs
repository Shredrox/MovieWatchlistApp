using System;

namespace MovieWatchlist.Services
{
    public interface IWindowActions
    {
        Action? Close { get; set; }
        Action? Minimize { get; set; }
    }
}
