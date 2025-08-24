using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Utilities
{
    public class Polynomial
    {
        public List<float> Coefficients { get; private set; }
        public Polynomial(List<float> coefficients)
        {
            Coefficients = coefficients;
        }
        public float Evaluate(float x)
        {
            float result = 0;
            for (int i = 0; i < Coefficients.Count; i++)
            {
                result += Coefficients[i] * (float)Math.Pow(x, Coefficients.Count - i - 1);
            }
            return result;
        }
        public Polynomial Derivative()
        {
            List<float> derivativeCoefficients = new List<float>();
            for (int i = 1; i < Coefficients.Count; i++)
            {
                derivativeCoefficients.Add(Coefficients[i] * i);
            }
            return new Polynomial(derivativeCoefficients);
        }
    }




    }
