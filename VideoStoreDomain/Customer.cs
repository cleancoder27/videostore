namespace VideoStoreDomain
{
    public class Customer
    {
        public Customer(string aName)
        {
            name = aName;
        }

        public void addRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public string getName()
        {
            return name;
        }

        public String statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + getName() + "\n";

            foreach (var rental in rentals)
            {
                double thisAmount = 0;

                // determines the amount for each line
                switch (rental.getMovie().getPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (rental.getDaysRented() > 2)
                            thisAmount += (rental.getDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += rental.getDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.getDaysRented() > 3)
                            thisAmount += (rental.getDaysRented() - 3) * 1.5;
                        break;
                }

                frequentRenterPoints++;

                if (rental.getMovie().getPriceCode() == Movie.NEW_RELEASE
                    && rental.getDaysRented() > 1)
                    frequentRenterPoints++;

                result += "\t" + rental.getMovie().getTitle() + "\t"
                          + $"{thisAmount:0.0}" + "\n";
                totalAmount += thisAmount;

            }

            result += "You owed " + $"{totalAmount:0.0}" + "\n";
            result += "You earned " +frequentRenterPoints + " frequent renter points\n";


            return result;
        }



		private String name;
       private List<Rental> rentals = new List<Rental>();
    }
}