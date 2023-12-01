// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

var file = System.IO.File.ReadAllLines("Day1Input.txt");
 
List<int> numbers = new();

foreach (var line in file)
{
    var number = new StringBuilder();
    var result = GetNumbersFromString(line);
    if (result != 0)
    {
        numbers.Add(result);
    }
}

// Add all the numbers together

var total = numbers.Sum();

Console.WriteLine($"Total: {total}");

int GetNumbersFromString(string s)
{

    int number = 0;
    string[] words = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    List<KeyValuePair<int, int>> found = new();

    foreach (var word in words)
    {
        int index = 0;
        while (s.IndexOf(word, index) >= 0)
        {
            int startIndex = s.IndexOf(word, index);
            var converted = ConvertNumber(word);
            found.Add(new KeyValuePair<int, int>(converted, startIndex));
            index = startIndex + word.Length;
        }
    }

    // find the first numeric character
    foreach (var @char in s.ToCharArray())
    {
        if (Regex.IsMatch(@char.ToString(), "[0-9]"))
        {
            found.Add(new KeyValuePair<int, int>(int.Parse(@char.ToString()), s.IndexOf(@char)));
            break;
        }
    }

    // find the last numeric character
    foreach (var @char in s.ToCharArray().Reverse())
    {
        if (Regex.IsMatch(@char.ToString(), "[0-9]"))
        {
            found.Add(new KeyValuePair<int, int>(int.Parse(@char.ToString()), s.LastIndexOf(@char)));
            break;
        }
    }


    var first = found.OrderBy(_ => _.Value).Take(1).First();
    var last = found.OrderBy(_ => _.Value).TakeLast(1).First();

    var result = int.Parse($"{first.Key}{last.Key}");
    System.Console.WriteLine($"{s}\t\t\t{result}");
    return result;
}

static int ConvertNumber(string input) => input switch
{
    "one" => 1,
    "two" => 2,
    "three" => 3,
    "four" => 4,
    "five" => 5,
    "six" => 6,
    "seven" => 7,
    "eight" => 8,
    "nine" => 9,
    _ => 0
};