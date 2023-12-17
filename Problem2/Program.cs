using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "numbers.txt");

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            string concatAllText = string.Join(" ", lines);

            var matchedNumbers = Regex.Matches(concatAllText, @"\d+")
                .Cast<Match>()
                .Select(match => int.Parse(match.Value));

            var topNumbers = matchedNumbers
                .GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key);

            Console.WriteLine("Five numbers that occurs most times:");

            foreach (var number in topNumbers)
            {
                Console.WriteLine(number);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file 'numbers.txt' was not found!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}