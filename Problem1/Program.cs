class Program
{
    static void Main()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(path, "palindromes.txt");

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (ContainsPalindrome(line))
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("'palindromes.txt' file was not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    static bool ContainsPalindrome(string fileLines)
    {
        string newFileLines = new string(fileLines
            .Where(c => Char.IsLetterOrDigit(c))
            .ToArray())
            .ToLower();

        return newFileLines.SequenceEqual(newFileLines.Reverse());
    }
}