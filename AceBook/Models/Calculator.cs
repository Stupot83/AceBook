using System;
namespace AceBook.Models
{
    public class Calculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Minus(int num1, int num2)
        {
            return num1 - num2;
        }

        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public float Divide(float num1, float num2)
        {
            return num1 / num2;
        }
    }
}
