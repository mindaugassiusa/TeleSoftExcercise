using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TeleSoftExcercise
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Write full path, including file name.
            Console.WriteLine("Enter full path to file you would like to read text from.");
            string inputFilePath = Console.ReadLine();

            Console.WriteLine("Enter maximum length of one line");
            int maxLineLength = Convert.ToInt32(Console.ReadLine());

            TextConverter(inputFilePath, maxLineLength);
        }

        public static void TextConverter(string inputFilePath, int maxLineLength)
        {
            if (maxLineLength <= 0)
            {
                throw new Exception("Entered value of max line length is invalid");
            }

            if (!File.Exists(inputFilePath))
            {
                throw new Exception("Entered input file path does not exist");
            }
            //You will find output.txt file in the following path: "\TeleSoftTask\TeleSoftTask\bin\Debug\netcoreapp2.1".
            string outputFilePath = "output.txt";

            StreamWriter output = new StreamWriter(outputFilePath);

            string text = Regex.Replace(File.ReadAllText(inputFilePath), @"\r\n", " ");

            while (text.Length > maxLineLength)
            {
                output.WriteLine(text.Substring(0, maxLineLength));

                text = text.Substring(maxLineLength);
            }

            if (text.Length > 0)
            {
                output.WriteLine(text);
            }

            output.Close();

            Console.WriteLine("Press any button to close program");
            Console.ReadKey();
        }
    }
}
