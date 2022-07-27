using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStoreDomain
{
    public class Rental
    {
        public Rental(Movie aMovie, int theDaysRented)
        {
            movie = aMovie;
            daysRented = theDaysRented;
        }

        public int getDaysRented()
        {
            return daysRented;
        }

        public Movie getMovie()
        {
            return movie;
        }

        private Movie movie;
        private int daysRented;
    }
}
