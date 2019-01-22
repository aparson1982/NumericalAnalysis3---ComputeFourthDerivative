using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalAnalysis4
{
    class Problem3
    {
        private const double x = Math.PI / 8;

        /// <summary>
        /// iterates and returns all the values for h
        /// </summary>
        public static double[] H  
        {
            get
            {
                double[] h = new double[5];
                for (int i = 0; i < h.Length; i++)
                {
                    h[i] = 1 / Math.Pow(3, i + 1);
                }
                return h;
            }
        }

        /// <summary>
        /// This method returns 4th derivative of f(x)=cos(2x), which is 16cos(2x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double ExactValue(double x) 
        {
            return 16 * Math.Cos(2 * x);
        }

        /// <summary>
        /// This method accepts an argument and returns the value for f(x)=cos(2x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Math.Cos(2 * (x))</returns>
        private static double Function(double x) 
        {
            return Math.Cos(2 * (x));
        }

        /// <summary>
        /// This method calls and displays the Exact value of the 4th derivative.
        /// The method also calculates and displays the Numerical Approximation, and the absolute value of the error for each choice of h.
        /// </summary>
        private static void FindSolution()
        {
            double[] h = H;  //initializes new Array h and sets the values equal to the returned values from method H
            //new Problem3();  //instantiates a new instance of the class Problem3
            double numericalApproximation;  //initializes variable numericalApproximation which has double precision
            double absoluteError;   //initializes variable absolute which has double precision

            Console.WriteLine("\nThe exact value of the fourth derivative of cos(2x) where x=pi/8 =    " + ExactValue(x));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("The Numerical Approximations and Errors for the 4th Derivative of cos(2x) where x=pi/8 are as follows:");
            for (int i = 0; i < 5; i++) //iterates through every value of h and computes 4th derivative using the formula and then prints the results
            {
                numericalApproximation = (Function(x - 2 * h[i]) - 4 * Function(x - h[i]) + 6 * Function(x) - 4 * Function(x + h[i]) + Function(x + 2 * h[i])) / Math.Pow(h[i], 4);
                absoluteError = Math.Abs(numericalApproximation - ExactValue(x));  //Finds and returns the absolute value of the difference of the exact value and the numerical approximation
                Console.WriteLine("For  h=1/(3^" + (i + 1) + ")= " + h[i] + " : 4th derivative (f^4(x))= " + numericalApproximation + " : absolute error= " + absoluteError);
            }
            Console.ReadLine();
        }

        public static void Main(string[] args)  //Main entry point
        {
            FindSolution();  //Call to Find Solution Method
        }
    }
}
