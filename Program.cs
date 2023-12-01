// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

var file = System.IO.File.ReadAllLines("Day1Input.txt");

Console.WriteLine(file);

List<int> numbers = new();

foreach (var line in file)
{
    var number = new StringBuilder();

    // find the first numeric character
    foreach (var @char in line.ToCharArray())
    {
        if (Regex.IsMatch(@char.ToString(), "[0-9]"))
        {
            number.Append(@char);
            break;
        }
    }

    // find the last numeric character
    foreach (var @char in line.ToCharArray().Reverse())
    {
        if (Regex.IsMatch(@char.ToString(), "[0-9]"))
        {
            number.Append(@char);
            break;
        }
    }  

    var twoDigitNumber = int.Parse(number.ToString());

    numbers.Add(twoDigitNumber);
}


// Add all the numbers together

var total = numbers.Sum();

Console.WriteLine($"Total: {total}");