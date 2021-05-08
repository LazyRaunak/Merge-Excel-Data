using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Excel_Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = @"C:\Users\Raunak\Downloads\New Space Tech\Test File1.csv";
            string second = @"C:\Users\Raunak\Downloads\New Space Tech\Test File2.csv";

            string file1 = File.ReadAllText(first);
            string file2 = File.ReadAllText(second);

            string file3 = string.Concat(file1, file2);
            string[] rows = file3.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] rowData;
            string[,] data = new string[rows.Length, 2];

            for (int i = 0; i < rows.Length; i++)
            {
                rowData = rows[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if ((rowData[0] != null) && (rowData[1] != null))
                    {
                        data[i, 0] = rowData[0];
                        data[i, 1] = rowData[1];
                    }
                }

                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            var dict = new Dictionary<string, string>();
            for (int i = 0; i < rows.GetLength(0); i++)
                if ((data[i, 0] != null) && (data[i, 1] != null))
                {
                    dict[data[i, 0]] = data[i, 1];
                }

            var items = from pair in dict orderby pair.Key ascending select pair;

            foreach (KeyValuePair<string, string> pair in items)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();

        }
    }
}
