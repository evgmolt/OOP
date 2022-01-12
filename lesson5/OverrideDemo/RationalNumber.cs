using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverrideDemo
{
    internal class RationalNumber
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public RationalNumber(int numenator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Division by zero");
            }
            _numerator = numenator;
            _denominator = denominator;
            //Здесь напрашивается вызов метода сокращения дроби до наименьшего значения,
            //но в задании этого не было.
        }

        public static RationalNumber operator +(RationalNumber first, RationalNumber second)
        {
            return new RationalNumber(
                (first._numerator * second._denominator) + (second._numerator * first._denominator),
                first._denominator * second._denominator);
        }

        public static RationalNumber operator -(RationalNumber first, RationalNumber second)
        {
            return new RationalNumber(
                (first._numerator * second._denominator) - (second._numerator * first._denominator),
                first._denominator * second._denominator);
        }

        public static RationalNumber operator ++(RationalNumber number)
        {
            return number + new RationalNumber(1, 1);
        }

        public static RationalNumber operator --(RationalNumber number)
        {
            return number - new RationalNumber(1, 1);
        }

        public static RationalNumber operator *(RationalNumber first, RationalNumber second)
        {
            return new RationalNumber(
                first._numerator * second._numerator, 
                first._denominator * second._denominator);
        }

        public static RationalNumber operator /(RationalNumber first, RationalNumber second)
        {
            return new RationalNumber(
                first._numerator * second._denominator,
                first._denominator * second._numerator);
        }

        public static bool operator ==(RationalNumber first, RationalNumber second)
        {
            if (first is null && second is null) return true;
            if (first is null || second is null) return false;
            return first._numerator / first._denominator == second._numerator / second._denominator;
        }

        public static bool operator !=(RationalNumber first, RationalNumber second)
        {
            return first._numerator / first._denominator != second._numerator / second._denominator;
        }

        public override bool Equals(object obj)
        {
            return this == (RationalNumber)obj;
        }

        public override int GetHashCode()
        {
            return _numerator ^ _denominator;
        }

        public override string ToString()
        {
            return _numerator.ToString() + "/" + _denominator.ToString();
        }

        public static implicit operator float(RationalNumber r) 
        {
            return (float)r._numerator / r._denominator;
        }

        public static implicit operator int(RationalNumber r)
        {
            return (int)r._numerator / r._denominator;
        }
    }
}
