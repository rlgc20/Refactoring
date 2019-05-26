using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Refactoring
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerable<Rental> rentals = _rentals.ToArray();
            string result = "Rental Record For" + getName() + "\n";

            while (rentals.Count() > 0)
            {
                double thisAmount = 0;
                Rental each = rentals.Last();

                //determine amount for each line
                thisAmount = each.getCharge() ;

                //add frequent render points
                frequentRenterPoints++;
                //add bonus for a two day new release rental
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) && each.getDaysRented() > 1)
                    frequentRenterPoints++;

                //show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";
            return result;
        }

    }
}
