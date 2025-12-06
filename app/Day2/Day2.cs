using Common;

namespace Day2;

class Main
{
    public static void Run()
    {
        string[] lines = Util.ReadInputFile("../../../Day2/input.txt");
        string[] ranges = lines[0].Split(",");

        RunPart1(ranges);
        // RunPart2(lines);
    }

    public static void RunPart1(string[] ranges)
    {
        HashSet<double> invalidNumbers = new HashSet<double>();

        foreach (string r in ranges)
        {
            string leftString = r.Split("-")[0];
            string rightString = r.Split("-")[1];

            double leftNumber = double.Parse(leftString);
            double rightNumber = double.Parse(rightString);

            // both left and right are of even length
            // iterate with both halves as limits
            if (leftString.Length % 2 == 0 && rightString.Length % 2 == 0)
            {
                string leftHalfString = leftString.Substring(0, leftString.Length / 2);
                string rightHalfString = rightString.Substring(0, rightString.Length / 2);

                double n1 = double.Parse(leftHalfString);
                double n2 = double.Parse(rightHalfString);

                for (double i = n1; i <= n2; i++)
                {
                    string s = i.ToString();
                    string str = s + s;
                    double n = double.Parse(str);
                    if (leftNumber <= n && n <= rightNumber)
                    {
                        invalidNumbers.Add(n);
                    }
                }
            }

            // left is even length, right is odd 
            // example: 95-777
            // minimum value is the left number
            // maximum value is 99 (last even number)
            if (leftString.Length % 2 == 0 && rightString.Length % 2 == 1)
            {
                // get max length value
                int maxLength = rightString.Length - 1;
                string maxValueString = new string('9', maxLength);
                double maxValue = double.Parse(maxValueString);

                string leftHalfString = leftString.Substring(0, leftString.Length / 2);
                double minValue = double.Parse(leftHalfString);
                for (double i = minValue; i <= maxValue; i++)
                {
                    string s = i.ToString();
                    string str = s + s;
                    double n = double.Parse(str);
                    if (leftNumber <= n && n <= rightNumber)
                    {
                        invalidNumbers.Add(n);
                    }
                }
            }

            // left is odd length, right is even length
            // example: 998-4600
            // minimum value for the P1 pattern is 1000 (1st even number)
            // maxaimum value is the right number
            if (leftString.Length % 2 == 1 && rightString.Length % 2 == 0)
            {
                // get min value
                int minLength = leftString.Length;
                string minValueString = '1' + new string('0', minLength);

                string minValueHalfString = minValueString.Substring(0, minValueString.Length / 2);
                double minValueHalf = double.Parse(minValueHalfString);
                for (double i = minValueHalf; i <= rightNumber; i++)
                {
                    string s = i.ToString();
                    string str = s + s;
                    double n = double.Parse(str);
                    if (leftNumber <= n && n <= rightNumber)
                    {
                        invalidNumbers.Add(n);
                    }
                }
            }
        }
        // invalidNumbers.ToList().ForEach(x => Console.WriteLine(x + " "));
        Console.WriteLine("Sum of invalid IDs = {0}", invalidNumbers.Sum());
    }
}