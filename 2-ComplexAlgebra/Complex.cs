using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    public class Complex
    {
        // TODO: fill this class\
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imag)
        {
            this.Real = real;
            this.Imaginary = imag;
        }

        public double Modulus => Math.Sqrt(Real*Real + Imaginary*Imaginary);

        public double Phase => Math.Atan2(Imaginary,Real);

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex c2) => new Complex(Real + c2.Real, Imaginary + c2.Imaginary);

        public Complex Minus(Complex c2) => new Complex(Real - c2.Real, Imaginary - c2.Imaginary);

        public override string ToString()
        {
            if (Real == 0 && Imaginary == 0)
            {
                return "0";
            } else
            return (Real == 0 ? "" : $"{Real}") + 
                   (Imaginary == 0 ? "" : (Imaginary >= 0 ? $"+i{Imaginary}" : $"-i{-Imaginary}"));
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex && Real == complex.Real && Imaginary == complex.Imaginary;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}