using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public class ChildrensPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.CHILDRENS;
        }

        public override double getCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}
