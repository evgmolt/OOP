using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverrideDemo
{
    internal class ComplexNumber
    {
        private readonly double _real;
        private readonly double _imaginary;

        public ComplexNumber(double real, double imaginary) 
        {
            _real = real;
            _imaginary = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first._real + second._real, first._imaginary + second._imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first._real - second._real, first._imaginary - second._imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first._real * second._real - first._imaginary * second._imaginary,
           first._real * second._imaginary + first._imaginary * second._real);
        }

        public static ComplexNumber operator /(ComplexNumber first, ComplexNumber second)
        {
            double Denominator = second._real * second._real + second._imaginary * second._imaginary;
            return new ComplexNumber(
                (first._real * second._real + first._imaginary * second._imaginary) / Denominator,
                (second._real * first._imaginary - second._imaginary * first._real) / Denominator);
        }

        public static bool operator ==(ComplexNumber first, ComplexNumber second)
        {
            if (first is null && second is null) return true;
            if (first is null || second is null) return false;
            return first._real == second._real && first._imaginary == second._imaginary;
        }

        public static bool operator !=(ComplexNumber first, ComplexNumber second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            return this == (ComplexNumber)obj;
        }

        public override int GetHashCode()
        {
            return (int)_real ^ (int)_imaginary;
        }

        public override string ToString()
        {
            return _real.ToString() + " + " + _imaginary.ToString() + "i";
        }
    }
}
