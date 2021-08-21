using System.IO;

namespace CodeScriptWriter
{
    class Program
    {
        private const int ratio = 500;
        private const int lenght = 300000; // For each operation
        private const string path = @"..\..\..\Calculator\Program.cs";

        static void Main()
        {
            string[] lines = new string[15];

            lines[0] = "using System;";
            lines[1] = "using System.Linq;\n";
            lines[2] = "namespace CodeScriptWriter";
            lines[3] = "{";
            lines[4] = "    class Program";
            lines[5] = "    {";
            lines[6] = "        static void Main(string[] args)";
            lines[7] = "        {";

            lines[8] = @"            Console.WriteLine(""CALCULATOR\n"");";
            lines[9] = @"            Console.Write(""Enter Query: "");";
            lines[10] = "\n            var input = Console.ReadLine();";
            lines[11] = "            var operation = input.First(a => a == '+' || a == '-' || a == '*' || a == '/');";
            lines[12] = "            var query = input.Split(operation).Select(a => a.Trim()).ToArray();\n";
            lines[13] = @"            if (query[0] == ""1"" && operation == '+' && query[1] == ""1"")";
            lines[14] = @"                Console.WriteLine(""\nResult: 2"");" + "\n";

            File.WriteAllLines(path, lines);

            lines = new string[lenght];
            for (int i = 0, a = 1, b = 2; i + 1 < lines.Length; i += 2)
            {
                lines[i] = $@"            if (query[0] == ""{a}"" && operation == '+' && query[1] == ""{b}"")";
                lines[i + 1] = $@"               Console.WriteLine(""\nResult: {a + b}"");" + "\n";
                b++;
                if (b > ratio)
                {
                    b = 1;
                    a++;
                }
            }
            File.AppendAllLines(path, lines);

            lines = new string[lenght];
            for (int i = 0, a = ratio, b = 1; i + 1 < lines.Length; i += 2)
            {
                lines[i] = $@"            if (query[0] == ""{a}"" && operation == '-' && query[1] == ""{b}"")";
                lines[i + 1] = $@"               Console.WriteLine(""\nResult: {a - b}"");" + "\n";
                b++;
                if (b > ratio)
                {
                    b = 1;
                    a--;
                }
            }
            File.AppendAllLines(path, lines);

            lines = new string[lenght];
            for (int i = 0, a = 1, b = 1; i + 1 < lines.Length; i += 2)
            {
                lines[i] = $@"            if (query[0] == ""{a}"" && operation == '*' && query[1] == ""{b}"")";
                lines[i + 1] = $@"               Console.WriteLine(""\nResult: {a * b}"");" + "\n";
                b++;
                if (b > ratio)
                {
                    b = 1;
                    a++;
                }
            }
            File.AppendAllLines(path, lines);

            lines = new string[lenght];
            for (int i = 0, a = ratio, b = 1; i + 1 < lines.Length; i += 2)
            {
                lines[i] = $@"            if (query[0] == ""{a}"" && operation == '/' && query[1] == ""{b}"")";
                lines[i + 1] = $@"               Console.WriteLine(""\nResult: {(double)a / b}"");" + "\n";
                b++;
                if (b > ratio)
                {
                    b = 1;
                    a--;
                }
            }
            File.AppendAllLines(path, lines);

            lines = new string[4];
            lines[0] = "            Console.ReadLine();";
            lines[1] = "        }";
            lines[2] = "    }";
            lines[3] = "}";

            File.AppendAllLines(path, lines);
        }
    }
}
