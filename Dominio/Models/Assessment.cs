using Dominio.Models.Base;
using System;

namespace Domain.Models
{
    public class Assessment : BaseEntity
    {
        public Assessment(int movieScore, User user, Movie movie)
        {
            Id = Guid.NewGuid();
            MovieScore = movieScore;
            User = user;
            Movie = movie;
        }

        public int MovieScore { get; private set; }
        public User User { get; private set; }
        public Movie Movie { get; private set; }
    }
}
