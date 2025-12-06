using Common;

namespace Day1;

class Main
{
    private static int DIAL_LENGTH = 100;

    public static void Run()
    {
        string[] lines = Util.ReadInputFile("../../../Day1/input.txt");

        RunPart1(lines);
        RunPart2(lines);
    }

    public static void RunPart1(string[] lines)
    {
        int dialAtZero = 0;
        int currentPos = 50;
        foreach (string line in lines)
        {
            char direction = line[0];
            int rotation = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                currentPos = (currentPos - rotation) % DIAL_LENGTH;
                if (currentPos < 0)
                {
                    currentPos += DIAL_LENGTH;
                }
            }
            if (direction == 'R')
            {
                currentPos += rotation;
                currentPos %= DIAL_LENGTH;
            }

            if (currentPos == 0)
            {
                dialAtZero++;
            }
        }
        Console.WriteLine("Part 1 -- Went to 0, {0} times", dialAtZero);
    }

    public static void RunPart2(string[] lines)
    {
        int dialAtZero = 0;
        int dialThroughZero = 0;
        int currentPos = 50;
        foreach (string line in lines)
        {
            char direction = line[0];
            int rotation = int.Parse(line.Substring(1));

            if (direction == 'L')
            {
                int nextPos = currentPos - rotation;
                if (nextPos < 0)
                {
                    dialThroughZero += Math.Abs((int)Math.Floor((decimal)nextPos / DIAL_LENGTH));
                    // do not count twice if it was already at 0 before rotating
                    if (currentPos == 0)
                    {
                        dialThroughZero -= 1;
                    }
                }

                currentPos = nextPos % DIAL_LENGTH;
                // actual position on dial
                if (currentPos < 0)
                {
                    currentPos += DIAL_LENGTH;
                }
            }

            if (direction == 'R')
            {
                int nextPos = currentPos + rotation;
                if (nextPos > 0)
                {
                    dialThroughZero += (int)Math.Floor((decimal)currentPos / DIAL_LENGTH);
                    // do not count twice if it was already at 0 before rotating
                    if (currentPos == 0)
                    {
                        dialThroughZero -= 1;
                    }
                }
                currentPos = nextPos % DIAL_LENGTH;
            }

            if (currentPos == 0)
            {
                dialAtZero++;
                dialThroughZero++;
            }
        }
        Console.WriteLine("Part 2 -- Went to 0, {0} times", dialAtZero);
        Console.WriteLine("Part 2 -- Went through 0, {0} times", dialThroughZero);
    }
}