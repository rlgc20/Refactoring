using System;

namespace Refactoring
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private string _title;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            _title = title;
            setPriceCode(priceCode);
        }

        public int getPriceCode()
        {
            return _price.getPriceCode();
        }

        public void setPriceCode(int arg)
        {
            switch (arg)
            {
                case REGULAR:
                    _price = new RegularPrice();
                    break;
                case CHILDRENS:
                    _price = new ChildrensPrice();
                    break;
                case NEW_RELEASE:
                    _price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentException("Incorrect Price Code");
            }
        }

        public string getTitle()
        {
            return _title;
        }

        public double getCharge(int daysRented)
        {
            return _price.getCharge(daysRented);
        }

        public int getFrequentRenterPoints(int daysRented)
        {
            return _price.getFrequentRenterPoints(daysRented);
        }
    }
}
