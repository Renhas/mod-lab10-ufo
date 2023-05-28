using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufo
{
    static public class MyMath
    {
        private const double PI = Math.PI;
        static public double Atn(double x, int count) 
        {
            double result = 0;
            bool reversive = false;
            if (Math.Abs(x) > 1) 
            {
                x = 1 / x;
                reversive = true;
            }

            int one = 1;
            double current_x = x;
            double denominator = 1;
            for (int i = 0; i < count; i++) 
            {
                result += one * current_x / denominator;
                one *= -1;
                current_x *= x * x;
                denominator += 2;
            }
            if (reversive) 
            {
                result = PI / 2 - result;
            }
            return result;
        }

        static public double Cos(double x, int count) 
        {
            double result = 0;

            int one = 1;
            double current_x = 1;
            double denominator = 1;
            for (int i = 0; i < count; i++)
            {
                result += one * current_x / denominator;
                one *= -1;
                current_x *= x * x;
                denominator *= (2*i + 1) * (2*i + 2);
            }

            return result;
        }

        static public double Sin(double x, int count) 
        {
            double result = 0;

            int one = 1;
            double current_x = x;
            double denominator = 1;
            for (int i = 0; i < count; i++)
            {
                result += one * current_x / denominator;
                one *= -1;
                current_x *= x * x;
                denominator *= (2 * i + 2) * (2 * i + 3);
            }

            return result;

        }
    }
}
