using System;
using System.Text;

namespace NET.W._2019.Gorodko._04.Task1
{
    /// <summary>
    /// Class for working with polynomials
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Contains coefficients of polynomial
        /// </summary>
        private readonly double[] _coefficients;

        #region Constructors

        /// <summary>
        /// Creates the polynomial with certain degree  
        /// </summary>
        /// <param name="degree">Degree</param>
        public Polynomial(int degree = 0)
        {
            if (degree < 0)
            {
                throw new ArgumentException("degree must be positive");
            }

            _coefficients = new double[degree + 1];
        }

        /// <summary>
        /// Creates the polynomial with certain coefficients
        /// </summary>
        /// <param name="coefficients">Coefficients</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException("Lenght of the array can't be 0");
            }

            _coefficients = coefficients;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Contains the degree of the polynomial
        /// </summary>
        public int Degree
        {
            get
            {
                return _coefficients.Length - 1;
            }
        }

        /// <summary>
        /// Provides access to the array of coefficients
        /// </summary>
        /// <param name="number">Index</param>
        public double this[int number]
        {
            get
            {
                if (number >= _coefficients.Length || number < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return _coefficients[number];
            }

            set
            {
                if (number >= _coefficients.Length || number < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                _coefficients[number] = value;
            }
        }

        #endregion

        #region Overrided operators

        /// <summary>
        /// Summate each coefficient of left and right arguments
        /// </summary>
        /// <param name="leftArg">Left argument</param>
        /// <param name="rightArg">Right argument</param>
        /// <returns>Result of summation of two polynomials</returns>
        public static Polynomial operator +(Polynomial leftArg, Polynomial rightArg)
        {
            if (leftArg == null)
            {
                throw new ArgumentNullException(nameof(leftArg));
            }

            if (rightArg == null)
            {
                throw new ArgumentNullException(nameof(rightArg));
            }

            var degree = leftArg.Degree > rightArg.Degree ? leftArg.Degree : rightArg.Degree;

            var result = new Polynomial(degree);

            for (int i = 0; i <= leftArg.Degree; i++)
            {
                result[i] = leftArg[i];
            }

            for (int i = 0; i <= rightArg.Degree; i++)
            {
                result[i] += rightArg[i];
            }

            return result;
        }

        /// <summary>
        /// Differences of each coefficient of left and right arguments
        /// </summary>
        /// <param name="leftArg">Left argument</param>
        /// <param name="rightArg">Right argument</param>
        /// <returns>Result of difference of two polynomials</returns>
        public static Polynomial operator -(Polynomial leftArg, Polynomial rightArg)
        {
            if (leftArg == null)
            {
                throw new ArgumentNullException(nameof(leftArg));
            }

            if (rightArg == null)
            {
                throw new ArgumentNullException(nameof(rightArg));
            }

            var degree = leftArg.Degree > rightArg.Degree ? leftArg.Degree : rightArg.Degree;

            var result = new Polynomial(degree);

            for (int i = 0; i <= leftArg.Degree; i++)
            {
                result[i] = leftArg[i];
            }

            for (int i = 0; i <= rightArg.Degree; i++)
            {
                result[i] -= rightArg[i];
            }

            return result;
        }

        /// <summary>
        /// Multiplies two polynomials
        /// </summary>
        /// <param name="leftArg">Left argument</param>
        /// <param name="rightArg">Right argument</param>
        /// <returns>Result of multiplication of two polynomials</returns>
        public static Polynomial operator *(Polynomial leftArg, Polynomial rightArg)
        {
            if (leftArg == null)
            {
                throw new ArgumentNullException(nameof(leftArg));
            }

            if (rightArg == null)
            {
                throw new ArgumentNullException(nameof(rightArg));
            }

            var result = new Polynomial(leftArg.Degree + rightArg.Degree);

            for (int i = 0; i <= leftArg.Degree; i++)
            {
                for (int j = 0; j <= rightArg.Degree; j++)
                {
                    result[i + j] += leftArg[i] * rightArg[j];
                }
            }

            return result;
        }

        /// <summary>
        /// Customizes polynomial to double array of coefficients
        /// </summary>
        /// <param name="polynom">Source polynomial</param>
        /// <returns>Array with coefficients</returns>
        public static implicit operator double[](Polynomial polynom)
        {
            if (polynom == null)
            {
                throw new ArgumentNullException(nameof(polynom));
            }

            return polynom._coefficients;
        }

        /// <summary>
        /// Customizes double array with coefficients to polynomial
        /// </summary>
        /// <param name="array">Array with coefficients</param>
        /// <returns>Polynomial</returns>
        public static implicit operator Polynomial(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return new Polynomial(array);
        }

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="leftArg">Left argument</param>
        /// <param name="rightArg">Right argument</param>
        /// <returns>Are polynomials same</returns>
        public static bool operator ==(Polynomial leftArg, Polynomial rightArg)
        {
            if (leftArg is null && rightArg is null)
            {
                return true;
            }

            if (leftArg is null)
            {
                return false;
            }

            return leftArg.Equals(rightArg);
        }

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="leftArg">Left argument</param>
        /// <param name="rightArg">Right argument</param>
        /// <returns>Are polynomials different</returns>
        public static bool operator !=(Polynomial leftArg, Polynomial rightArg)
        {
            return !(leftArg == rightArg);
        }

        #endregion

        #region Object overrided methods

        /// <summary>
        /// Returns string with polynomial
        /// </summary>
        /// <returns>String with polynomial</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _coefficients.Length; i++)
            {
                sb.Append($"+({_coefficients[i]})*x^{i} ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Compares polynomial and object
        /// </summary>
        /// <param name="obj">Object for comparing</param>
        /// <returns>Are object and polynomial equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Polynomial polynom))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.Degree != polynom.Degree)
            {
                return false;
            }

            for (int i = 0; i < _coefficients.Length; i++)
            {
                if (_coefficients[i] != polynom[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns hash code of the polynomial
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            double avg = 0;

            foreach (var coef in _coefficients)
            {
                avg += coef;
            }

            return (int)(avg / _coefficients.Length);
        }

        #endregion
    }
}
