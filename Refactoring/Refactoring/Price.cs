using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public abstract class Price
    {
        public abstract int getPriceCode();

        public abstract double getCharge(int daysRented);

        public virtual int getFrequentRenterPoints(int daysRented)
        {
            return 1;
        }

    }
}
