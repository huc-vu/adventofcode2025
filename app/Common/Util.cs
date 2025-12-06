namespace Common;

class Util
{
    public static string[] ReadInputFile(string path)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        return File.ReadAllLines(filePath);
    }
}