using static System.Console;
using System.Text.Json;

namespace Lab_1
{
    class Program
    {
        private static void PoemSorting()
        {
            WriteLine("Start entering the poem and press ENTER to finish...");
            List<string> poem = new List<string>();

            do {
                string line = ReadLine();
                if (line == "") break;
                poem.Add(line);
            } 
            while (true);
            
            Thread.Sleep(1000);
            Clear();

            List<string> sortedPoem = poem.OrderBy(x => x.Length).ToList();

            foreach (string s in sortedPoem)
                WriteLine(s);
            ReadKey();
            Clear();
        }

        private static void NewDictionary()
        {
            WriteLine("Enter the key and value. Press ENTER to finish...");
            Dictionary<int, string> dict = new Dictionary<int, string>();
            
            do
            {
                string line = ReadLine();
                if (line == "") break;
                string[] values = line.Split(" ");
                dict.Add(Convert.ToInt32(values[0]), values[1]);
            } while (true);

            WriteLine();

            Write("Enter your key: ");
            int key = Convert.ToInt32(Console.ReadLine());

            var result = dict.Where(x => x.Key >= key);
            WriteLine();
            WriteLine("Result: ");
            foreach (var res in result)
                WriteLine($"{res.Key} {res.Value}");
            
            ReadKey();

            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fs, result);
                WriteLine("Data has been saved.");
            }
        }

        private static void GetLineByLength()
        {
            WriteLine("Type in the lines. Press ENTER to finish...");
            List<string> lines = new List<string>();

            do
            {
                string line = ReadLine();
                if (line == "") break;
                lines.Add(line);
            } while (true);

            WriteLine();

            int num;
            do
            {
                WriteLine("Type in your number: ");
                num = Convert.ToInt32(ReadLine());
                if (num > 0) break;
                else WriteLine("Number must be greater than 0.");
                Thread.Sleep(1000);
                Clear();
            } while (true);

            var result = lines.LastOrDefault(x => x.Length == num && char.IsNumber(x[0]));
            WriteLine(result ?? "Not found");
            
            ReadKey();
        }
        
        static void Main(string[] args)
        {
            try
            {
                PoemSorting();
                NewDictionary();
                GetLineByLength();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}