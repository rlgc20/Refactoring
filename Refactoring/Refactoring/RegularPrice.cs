using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public class RegularPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.REGULAR;
        }

        public override double getCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;
            return result;
        }
    }
}
