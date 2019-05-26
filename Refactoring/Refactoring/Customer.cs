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

                //show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + each.getCharge().ToString() + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + getTotalCharge().ToString() + "\n";
            result += "You earned " + getTotalFrequentRenderPoints().ToString() + " frequent renter points";
            return result;
        }

        private double getTotalCharge()
        {
            double result = 0;
            IEnumerable<Rental> rentals = _rentals.ToArray();
            while(rentals.Count() > 0)
            {
                Rental each = rentals.Last();
                result += each.getCharge();
            }

            return result;
        }

        private int getTotalFrequentRenderPoints()
        {
            int result = 0;
            IEnumerable<Rental> rentals = _rentals.ToArray();
            while (rentals.Count() > 0)
            {
                Rental each = rentals.Last();
                result += each.getFrequentRenterPoints();
            }
            return result;
        }

        public string htmlStatement()
        {
            IEnumerable<Rental> rentals = _rentals.ToArray();
            string result = "<H1>Rentals for <EM>" + getName() + "</EM></H1><P>\n";

            while (rentals.Count() > 0)
            {
                Rental each = rentals.Last();
                // show figures for each rental
                result += each.getMovie().getTitle() + ": " +
                          each.getCharge().ToString() + "<BR>\n";
            }

            // add footer lines
            result += "<P>You owe <EM>" + getTotalCharge().ToString() + "</EM><P>\n";
            result += "On this rental you earned <EM>" +
                   getTotalFrequentRenderPoints().ToString() +
                   "</EM> frequent renter points<P>";
            return result;
        }
    }
}
